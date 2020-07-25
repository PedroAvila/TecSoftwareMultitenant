using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class OrdenInventarioRepository : BaseBusinessRepository<OrdenInventario>, IOrdenInventario<OrdenInventario>
    {
        public async Task<string> GenerarCodigo() //IOrdenInventario<OrdenInventario>
        {
            string codigo;
            using (var context = new BusinessContext())
            {
                var result = await context.OrdenInventarios.MaxAsync(x => x.NumeroOrden);
                int number = Convert.ToInt32(result);
                codigo = string.Format("{0:0000000000}", number + 1);
                return codigo;
            }
        }

        public async Task<IEnumerable<OrdenInventarioExtend>> SelectOrdenesInventario(CriteriaOrdenInventario filter)
        {
            using (var context = new BusinessContext())
            {
                var result = from oi in context.OrdenInventarios
                             where
                             (filter.HasNumberOrder && oi.NumeroOrden.Contains(filter.NumeroOrden))
                             ||
                             (filter.HasEstadoOrden && oi.EstadoOrden == filter.EstadoOrden)
                             ||
                             (filter.HasFechaEmisionDesde && oi.Fecha.Date >= filter.FechaEmisionDesde)
                             &&
                             (filter.HasFechaEmisionHasta && oi.Fecha.Date <= filter.FechaEmisionHasta)
                             select
                             new OrdenInventarioExtend()
                             {
                                 OrdenInventarioId = oi.OrdenInventarioId,
                                 NumeroOrden = oi.NumeroOrden,
                                 FechaEmision = oi.Fecha,
                                 EstadoOrden = oi.EstadoOrden
                             };
                return await result.ToListAsync();
            }
        }
    }
}
