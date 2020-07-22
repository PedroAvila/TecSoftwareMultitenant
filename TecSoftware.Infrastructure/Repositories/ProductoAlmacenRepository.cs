using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class ProductoAlmacenRepository : BaseRepository<ProductoAlmacen>, IProductoAlmacen<ProductoAlmacen>
    {
        public async Task<IEnumerable<ProductoAlmacenExtend>> ListaProductoAlmacen(int id)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = from pa in context.ProductoAlmacenes
                             join p in context.Productos on pa.ProductoId equals p.ProductoId
                             join pre in context.Presentaciones on pa.PresentacionId equals pre.PresentacionId
                             where pa.AlmacenId == id
                             select
                             new ProductoAlmacenExtend()
                             {
                                 ProductoAlmacenId = pa.ProductoAlmacenId,
                                 AlmacenId = pa.AlmacenId,
                                 ProductoId = pa.ProductoId,
                                 NombreProducto = p.Nombre,
                                 PresentacionId = pa.PresentacionId,
                                 NombrePresentacion = pre.Nombre,
                                 SaldoMinimo = pa.SaldoMinimo,
                                 SaldoMaximo = pa.SaldoMaximo,
                                 Saldo = pa.Saldo
                             };
                return await result.ToListAsync();
            }
        }

        public async Task UpdateProductoAlmacen(int producto, int almacen, decimal saldo)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var query = await (from pa in context.ProductoAlmacenes
                                   where pa.ProductoId == producto && pa.AlmacenId == almacen
                                   select pa).FirstOrDefaultAsync();
                query.Saldo = saldo;
                await context.SaveChangesAsync();
            }
        }
    }
}
