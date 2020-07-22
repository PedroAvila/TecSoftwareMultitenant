using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class MovimientoInventarioRepository : BaseRepository<MovimientoInventario>, IMovimientoInventario<MovimientoInventario>
    {
        public Task<decimal> ObtenerCantidadSaldoFinal(int producto)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = from mi in context.MovimientoInventarios
                             join pa in context.ProductoAlmacenes on mi.ProductoAlmacenId equals pa.ProductoAlmacenId
                             where pa.ProductoId == producto
                             select mi.CantidadSaldoFinal;

                return result.FirstOrDefaultAsync();
            }
        }
    }
}
