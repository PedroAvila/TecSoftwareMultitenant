using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class ProductoPrecioRepository : BaseRepository<ProductoPrecio>, IProductoPrecio<ProductoPrecio>
    {
        public async Task<IEnumerable<ProductoPrecioExtend>> ListaProductoPrecio(int id)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = from pp in context.ProductoPrecios
                             join p in context.Productos
                             on pp.ProductoId equals p.ProductoId
                             join m in context.Medidas
                             on p.MedidaId equals m.MedidaId
                             where pp.ListaPrecioId == id
                             select new ProductoPrecioExtend()
                             {
                                 ProductoPrecioId = pp.ProductoPrecioId,
                                 ListaPrecioId = pp.ListaPrecioId,
                                 ProductoId = pp.ProductoId,
                                 NombreProducto = p.Nombre,
                                 MedidaId = p.MedidaId,
                                 NombreMedida = m.Nombre,
                                 TipoPrecioId = (PrecioType)(pp.TipoPrecioId),
                                 CantidadMinima = pp.CantidadMinima,
                                 CantidadMaxima = pp.CantidadMaxima ?? 0,
                                 PrecioCompra = pp.PrecioCompra,
                                 Utilidad = pp.Utilidad,
                                 Pvp = pp.Pvp,
                                 ImporteMinimo = pp.ImporteMinimo
                             };
                return await result.ToListAsync();
            }
        }
    }
}
