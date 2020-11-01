using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class WebTenantProvider
    {
        private readonly InquilinoRepository _inquilinoRepository = new InquilinoRepository();
        private readonly List<Conexion> _conexionItem = new List<Conexion>();
        private List<Conexion> DetalleItemTemp => _conexionItem.ToList();
        private string _nameTenant = string.Empty;
        private readonly RequestDelegate _next;

        public WebTenantProvider(RequestDelegate next)
        {
            _next = next;
        }

        //public WebTenantProvider(IHttpContextAccessor accessor) : base()
        //{
        //    _nameTenant = accessor.HttpContext.User.Claims
        //        .Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).FirstOrDefault().Value;
        //}

        public async Task Invoke(HttpContext context)
        {
            //_nameTenant = await Task.Run(()=> accessor.HttpContext.User.Claims
            //    .Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).FirstOrDefault().Value);
            var apiKey = await Task.Run(() => context.User.FindFirst(ClaimTypes.Name)?.Value);

            _nameTenant = apiKey;
            await _next.Invoke(context);
        }

        private async Task GetConexions()
        {
            var entity = await _inquilinoRepository.Single(x => x.Nombre == _nameTenant,
                new List<Expression<Func<Inquilino, object>>>() { x => x.BaseDato });

            var conexion = new Conexion()
            {
                Tenant = entity.Nombre,
                DatabaseConnectionString = entity.BaseDato.DatabaseConnectionString
            };

            AgregarConexion(conexion);
        }

        public async Task<string> GetName()
        {
            return await Task.Run(() => _nameTenant);
        }

        private void AgregarConexion(Conexion conexion)
        {

            foreach (var tenant in DetalleItemTemp)
            {
                //Si el tenant ya existe en la lista ya no lo agrego, solo establesco nombre de tenant
                if (tenant.Tenant == conexion.Tenant)
                {
                    _nameTenant = conexion.Tenant;
                }
                else
                {
                    //Si el tenant no existe lo agrego a la lista y establesco nombre de tenant
                    _conexionItem.Add(conexion);
                    _nameTenant = conexion.Tenant;
                }
            }

            if (DetalleItemTemp.Count == 0)
            {
                _conexionItem.Add(conexion);
                _nameTenant = conexion.Tenant;
            }
        }

        public async Task<IEnumerable<Conexion>> MostrarConexiones()
        {
            var exist = DetalleItemTemp.Any(x => x.Tenant == _nameTenant);
            if (!exist)
                await GetConexions();
            return await Task.Run(() => DetalleItemTemp.ToList());
        }
    }
}
