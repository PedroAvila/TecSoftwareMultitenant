using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class RequerimientoCompraRepository : BaseBusinessRepository<RequerimientoCompra>,
        IRequerimientoCompra<RequerimientoCompra>
    {
        public async Task<string> GenerarCodigo()
        {
            string codigo;
            using (var context = new BusinessContext())
            {
                var result = await context.RequerimientoCompras.MaxAsync(x => x.NumeroRequerimiento);
                int number = Convert.ToInt32(result);
                codigo = string.Format("{0:0000000000}", number + 1);
                return codigo;
            }
        }

        public async Task<IEnumerable<UniversalExtend>> SelectRequerimientoCompra(CriteriaDocumento filter)
        {
            using (var context = new BusinessContext())
            {
                var result = from rc in context.RequerimientoCompras
                             where
                             (filter.HasNumber && rc.NumeroRequerimiento.Contains(filter.Numero))
                             ||
                             (filter.HasEstado && (int)rc.Estado == filter.Estado)
                             ||
                             (filter.HasFechaDesde && rc.FechaEmision.Date >= filter.FechaDesde)
                             &&
                             (filter.HasFechaHasta && rc.FechaEmision.Date <= filter.FechaHasta)
                             select
                             new UniversalExtend()
                             {
                                 Id = rc.RequerimientoCompraId,
                                 NumeroComprobante = rc.NumeroRequerimiento,
                                 FechaEmision = rc.FechaEmision,
                                 EstadoRequerimiento = rc.Estado
                             };
                return await result.ToListAsync();
            }
        }
    }
}
