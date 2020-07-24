using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class ProductoOrdenInventarioRepository : BaseRepository<ProductoOrdenInventario>,
        IProductoOrdenInventario<ProductoOrdenInventario>
    {
        public async Task<IEnumerable<ProductoOrdenInventarioExtend>> ListaProductoOrdenInventario(int id)
        {
            using (var context = new BusinessContext())
            {
                var result = from po in context.ProductoOrdenInventarios
                             join p in context.Productos on po.ProductoId equals p.ProductoId
                             join c in context.ConceptoInventarios on po.ConceptoInventarioId equals c.ConceptoInventarioId
                             join pe in context.Presentaciones on po.PresentacionId equals pe.PresentacionId
                             join a in context.Almacenes on po.AlmacenId equals a.AlmacenId
                             where po.OrdenInventarioId == id
                             select
                             new ProductoOrdenInventarioExtend()
                             {
                                 Id = po.ProductoOrdenInventarioId,
                                 OrdenInventarioId = po.OrdenInventarioId,
                                 ProductoId = po.ProductoId,
                                 NombreProducto = p.Nombre,
                                 ConceptoInventarioId = po.ConceptoInventarioId,
                                 NombreConceptoInventario = c.Nombre,
                                 PresentacionId = po.PresentacionId,
                                 NombrePresentacion = pe.Nombre,
                                 TipoOperacion = po.TipoOperacion,
                                 AlmacenId = po.AlmacenId,
                                 NombreAlmacen = a.Nombre,
                                 Cantidad = po.Cantidad
                             };
                return await result.ToListAsync();
            }
        }

        /// <summary>
        /// Englobar los paréntesis en las fechas para que quede en rango igualmente con 
        /// El número de orden.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductoOrdenInventarioExtend>> SelectProductoOrdenesInventario(CriteriaProductoOrdenInventario filter)
        {
            using (var context = new BusinessContext())
            {
                var result = from po in context.ProductoOrdenInventarios
                             join p in context.Productos on po.ProductoId equals p.ProductoId
                             join pre in context.Presentaciones on po.PresentacionId equals pre.PresentacionId
                             join a in context.Almacenes on po.AlmacenId equals a.AlmacenId
                             join oi in context.OrdenInventarios on po.OrdenInventarioId equals oi.OrdenInventarioId
                             where
                             oi.EstadoOrden == OrdenInventarioStatus.Aprobado
                             &&
                             ((filter.HasNumberOrder && oi.NumeroOrden.Contains(filter.NumeroOrden))
                             ||
                             ((filter.HasFechaEmisionDesde && oi.Fecha.Date >= filter.FechaEmisionDesde)
                             &&
                             (filter.HasFechaEmisionHasta && oi.Fecha.Date <= filter.FechaEmisionHasta)))
                             select
                             new ProductoOrdenInventarioExtend()
                             {
                                 Id = po.ProductoOrdenInventarioId,
                                 NumeroOrden = oi.NumeroOrden,
                                 NombreProducto = p.Nombre,
                                 PresentacionId = po.PresentacionId,
                                 NombrePresentacion = pre.Nombre,
                                 AlmacenId = po.AlmacenId,
                                 NombreAlmacen = a.Nombre,
                                 Cantidad = po.Cantidad,
                                 TipoOperacion = po.TipoOperacion
                             };
                return await result.ToListAsync();
            }
        }
    }
}
