using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class NumeradorRepository : BaseRepository<NumeradorComprobante>, INumerador<NumeradorComprobante>
    {
        public async Task<string> NumeroSecuencial(int puntoEmision, int comprobante) //INumerador<NumeradorComprobante>
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await (from n in context.NumeradorComprobantes
                                    where n.PuntoEmisionId == puntoEmision && n.ComprobanteId == comprobante
                                    select n.Secuencial).MaxAsync();
                //if (string.IsNullOrEmpty(result))
                //    result = Convert.ToString(0);
                var numMax = Convert.ToInt32(result) + 1;
                var number = $"{Convert.ToInt32(numMax):000000000}";
                return number;
            }
        }

        public async Task UpdateNumerador(NumeradorComprobante entity)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var query = await (from n in context.NumeradorComprobantes
                                   where n.PuntoEmisionId == entity.PuntoEmisionId && n.ComprobanteId == entity.ComprobanteId
                                   select n).FirstOrDefaultAsync();
                query.Secuencial = entity.Secuencial;
                await context.SaveChangesAsync();
            }
        }
    }
}
