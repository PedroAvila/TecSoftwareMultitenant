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
    public class ServiceContextTenantProvider : ITenantProvider
    {

        private readonly InquilinoRepository _inquilinoRepository = new InquilinoRepository();
        private InquilinoExtend _inquilino;
        private string _nameTenant = string.Empty;
        private readonly List<Conexion> _conexionItem = new List<Conexion>();
        private List<Conexion> DetalleItemTemp => _conexionItem.ToList();

        public void AgregarConexion(Conexion conexion)
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

        public ServiceContextTenantProvider(IHttpContextAccessor contextAccessor)
        {
            _nameTenant = contextAccessor.HttpContext.User.Claims
                .Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).FirstOrDefault().Value;

            var inquilino = _inquilinoRepository.Single(x => x.Nombre == _nameTenant,
                new List<Expression<Func<Inquilino, object>>>() { x => x.BaseDato }).Result;

            if (inquilino != null)
            {
                var inquilinoExtend = new InquilinoExtend()
                {
                    InquilinoId = inquilino.InquilinoId,
                    Nombre = inquilino.Nombre,
                    Dominio = inquilino.Dominio,
                    PlanServicio = inquilino.PlanServicio,
                    FechaCreacion = inquilino.FechaCreacion,
                    FechaInicio = inquilino.FechaInicio,
                    FechaFin = inquilino.FechaFin,
                    DatabaseConnectionString = inquilino.BaseDato.DatabaseConnectionString,
                    Estado = inquilino.Estado
                };
                _inquilino = inquilinoExtend;
            }


            if (_inquilino != null)
            {
                var conexion = new Conexion()
                {
                    Tenant = _inquilino.Nombre,
                    DatabaseConnectionString = inquilino.BaseDato.DatabaseConnectionString
                };
                AgregarConexion(conexion);
            }
        }

        public async Task<InquilinoExtend> ObtenerTenant(string name)
        {
            var inquilino = await _inquilinoRepository.Single(x => x.Nombre == name,
                new List<Expression<Func<Inquilino, object>>>() { x => x.BaseDato });
            if (inquilino != null)
            {
                var inquilinoExtend = new InquilinoExtend()
                {
                    InquilinoId = inquilino.InquilinoId,
                    Nombre = inquilino.Nombre,
                    Dominio = inquilino.Dominio,
                    PlanServicio = inquilino.PlanServicio,
                    FechaCreacion = inquilino.FechaCreacion,
                    FechaInicio = inquilino.FechaInicio,
                    FechaFin = inquilino.FechaFin,
                    DatabaseConnectionString = inquilino.BaseDato.DatabaseConnectionString,
                    Estado = inquilino.Estado
                };
                _inquilino = inquilinoExtend;
                if (_inquilino != null)
                {
                    var conexion = new Conexion()
                    {
                        Tenant = _inquilino.Nombre,
                        DatabaseConnectionString = _inquilino.DatabaseConnectionString
                    };
                    AgregarConexion(conexion);
                }
            }
            return _inquilino;
        }

        public List<Conexion> GetConexions()
        {
            return DetalleItemTemp;
        }

        public string GetName()
        {
            return _nameTenant;
        }
    }
}
