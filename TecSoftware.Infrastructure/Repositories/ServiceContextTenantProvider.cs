using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class ServiceContextTenantProvider : ITenantProvider
    {
        //private readonly IHttpContextAccessor _contextAccessor;
        private readonly InquilinoRepository _inquilinoRepository = new InquilinoRepository();
        private InquilinoExtend _inquilino;

        //public ServiceContextTenantProvider(IHttpContextAccessor contextAccessor)
        //{
        //    _contextAccessor = contextAccessor;

        //    //var host = _contextAccessor.HttpContext.Request.Host.Value;
        //    var tenant = _inquilinoRepository.Single(x => x.Nombre == "SocialMedia");
        //    //_inquilino = tenant.Result;
        //}

        public async Task ObtenerTenant(string tenant)
        {
            var inquilino = await _inquilinoRepository.Single(x => x.Nombre == tenant,
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
            }

        }

        public InquilinoExtend GetTenant()
        {
            return _inquilino;
        }
    }
}
