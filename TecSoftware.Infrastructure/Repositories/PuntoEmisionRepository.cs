using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class PuntoEmisionRepository : BaseRepository<PuntoEmision>, IPuntoEmision<PuntoEmision>
    {
        public async Task<IEnumerable<UniversalExtend>> ListaPtoEmision()
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var list = from p in context.PuntoEmisiones
                           join e in context.Establecimientos
                               on p.EstablecimientoId equals e.EstablecimientoId
                           select new UniversalExtend() { Id = p.PuntoEmisionId, Nombre = e.Nombre, Descripcion = p.Nombre };
                return await list.ToListAsync();
            }
        }

        public async Task<IEnumerable<UniversalExtend>> ListaPtoEmision(int id)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var list = from p in context.PuntoEmisiones
                           join e in context.Establecimientos
                               on p.EstablecimientoId equals e.EstablecimientoId
                           where p.EstablecimientoId == id
                           select new UniversalExtend() { Id = p.PuntoEmisionId, Nombre = e.Nombre, Descripcion = p.Nombre };
                return await list.ToListAsync();
            }
        }

        public async Task<string> NumeroSerie(int puntoEmision) //Poner Try Cach en dominio
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = from e in context.Establecimientos
                             join pe in context.PuntoEmisiones on e.EstablecimientoId equals pe.EstablecimientoId
                             where pe.PuntoEmisionId == puntoEmision
                             select e.Codigo + pe.Codigo;
                return await result.FirstAsync();
            }
        }

        public async Task UpdatePuntoEmision(PuntoEmision entity)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var query = await (from p in context.PuntoEmisiones
                                   where p.PuntoEmisionId == entity.PuntoEmisionId
                                   select p).FirstOrDefaultAsync();
                query.Estado = entity.Estado;
                await context.SaveChangesAsync();
            }
        }

    }
}
