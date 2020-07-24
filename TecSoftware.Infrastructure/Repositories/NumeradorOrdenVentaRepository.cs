using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class NumeradorOrdenVentaRepository : BaseRepository<NumeradorOrdenVenta>, INumeradorOrdenVenta<NumeradorOrdenVenta>
    {
        public async Task<string> NumeroSecuencial(int puntoEmision) //INumeradorOrdenVenta<NumeradorOrdenVenta>
        {
            using (var context = new BusinessContext())
            {
                var result = await (from no in context.NumeradorOrdenVentas
                                    where no.PuntoEmisionId == puntoEmision
                                    select no.Secuencial).MaxAsync();
                var numMax = Convert.ToInt32(result) + 1;
                var number = $"{Convert.ToInt32(numMax):000000000}";
                return number;
            }
        }

        public async Task UpdateNumeradorOrdenVenta(NumeradorOrdenVenta entity)
        {
            using (var context = new BusinessContext())
            {
                var query = (from no in context.NumeradorOrdenVentas
                             where no.PuntoEmisionId == entity.PuntoEmisionId
                             select no).FirstOrDefault();
                query.Secuencial = entity.Secuencial;
                await context.SaveChangesAsync();
            }
        }
    }
}
