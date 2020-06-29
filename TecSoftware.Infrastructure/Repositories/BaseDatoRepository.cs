using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class BaseDatoRepository : BaseRepository<BaseDato>, IBaseDato<BaseDato>
    {
        public async Task<IEnumerable<string>> GetAll(string nameTenan)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                //var result = await context.BaseDatos.Include(c => c.Inquilino)
                //    .Where(b => b.Inquilino.Nombre == nameTenan)
                //    .OrderByDescending(b => b.Nombre)
                //    .Take(5)
                //    .ToListAsync();
                //return result;

                var result = from b in context.BaseDatos
                             join i in context.Inquilinos on b.BaseDatoOfInquilinoId equals i.InquilinoId
                             where i.Nombre == nameTenan
                             select b.Nombre;
                return await result.Take(5).ToListAsync();
            }

        }
    }
}
