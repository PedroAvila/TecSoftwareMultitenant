using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class OrdenVentaRepository : BaseInquilinoRepository<OrdenVenta>, IOrdenVenta<OrdenVenta>
    {
        public async Task Registrar(OrdenVenta entity) //IOrdenVenta<OrdenVenta>
        {
            using (var context = new BusinessContext())
            {
                //VENTA
                context.Entry(entity).State = EntityState.Added;
                //DETALLE
                foreach (var d in entity.DetalleOrdenVentas)
                {
                    context.Entry(d).State = EntityState.Added;
                }
                await context.SaveChangesAsync();
            }
        }

        public async Task Actualizar(OrdenVenta entity)
        {
            using (var context = new BusinessContext())
            { //Técnica cuando esta fuera de contexto alguna propiedad como OrdenVentaId, cuando lo agregas por fuera.
                var local = context.Set<OrdenVenta>()
                    .Local
                    .FirstOrDefault(x => x.OrdenVentaId == entity.OrdenVentaId);
                if (local != null)
                    context.Entry(local).State = EntityState.Detached;
                //VENTA
                context.Entry(entity).State = EntityState.Modified;
                //DETALLE
                foreach (var d in entity.DetalleOrdenVentas)
                {
                    context.Entry(d).State = d.DetalleOrdenVentaId == default(int)
                        ? EntityState.Added
                        : EntityState.Modified;
                }
                await context.SaveChangesAsync();
            }
        }

        public async Task<string> CodigoNumerico()
        {
            using (var context = new BusinessContext())
            {
                var result = await (from ov in context.OrdenVentas
                                    select ov.CodigoNumerico).MaxAsync();
                var numMax = Convert.ToInt32(result) + 1;
                var number = $"{Convert.ToInt32(numMax):000000000}";
                return number;
            }
        }

        /// <summary>
        /// Filtro condicional para buscar ordenes de venta.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UniversalExtend>> SelectOrdenesDeVenta(CriteriaOrdenVenta filter)
        {
            using (var context = new BusinessContext())
            {
                var result = from ov in context.OrdenVentas
                             join c in context.Clientes on ov.ClienteId equals c.ClienteId
                             where
                                 (filter.Codigo == null || ov.CodigoNumerico.Contains(filter.Codigo))
                                 &&
                                 (!filter.ClienteId.HasValue || ov.ClienteId.Equals(filter.ClienteId.Value))
                                 &&
                                 (filter.FechaEmisionDesde == null || ov.FechaEmision.Date >= filter.FechaEmisionDesde)
                                 &&
                                 (filter.FechaEmisionHasta == null || ov.FechaEmision.Date <= filter.FechaEmisionHasta)
                                 //(filter.FechaEmisionHasta == null || ov.FechaEmision <= DbFunctions.TruncateTime(filter.FechaEmisionHasta))
                                 &&
                                 ov.Estado == OrdenVentaStatus.Emitido
                             select
                                 new UniversalExtend()
                                 {
                                     Id = ov.OrdenVentaId,
                                     NumeroComprobante = ov.NumeroComprobante,
                                     Descripcion = c.RazonSocial,
                                     FechaEmision = ov.FechaEmision,
                                     //FechaEntrega = ov.FechaEntrega,
                                     EstadoId = ov.Estado,
                                     Total = ov.Total
                                 };
                return await result.ToListAsync();
            }
        }

    }
}
