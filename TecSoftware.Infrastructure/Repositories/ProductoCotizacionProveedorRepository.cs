using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class ProductoCotizacionProveedorRepository : BaseBusinessRepository<ProductoCotizacionProveedor>,
        IProductoCotizacionProveedor<ProductoCotizacionProveedor>
    {
        private readonly List<ProductoCotizacionProveedorExtend> _detalleItem = new List<ProductoCotizacionProveedorExtend>();

        public List<ProductoCotizacionProveedorExtend> DetalleItemTemp => _detalleItem.ToList();

        public void Agregar(ProductoCotizacionProveedorExtend entity)
        {
            _detalleItem.Add(entity);
        }

        public void Remove(int id)
        {
            _detalleItem.RemoveAt(id);
        }

        public async Task<IEnumerable<CotizacionProveedorExtend>> BuscarCotizacionesXProducto(int producto)
        {
            using (var context = new BusinessContext())
            {
                var result = from pcp in context.ProductoCotizacionProveedores
                             join cp in context.CotizacionProveedores on pcp.CotizacionProveedorId equals cp.CotizacionProveedorId
                             join prv in context.Proveedores on cp.ProveedorId equals prv.ProveedorId
                             join p in context.Productos on pcp.ProductoId equals p.ProductoId
                             join m in context.Medidas on pcp.MedidaId equals m.MedidaId
                             where pcp.ProductoId == producto
                             select
                             new CotizacionProveedorExtend()
                             {
                                 ProductoCotizacionProveedorId = pcp.ProductoCotizacionProveedorId,
                                 NumeroCotizacion = cp.NumeroCotizacion,
                                 NombreProveedor = prv.RazonSocial,
                                 FechaFin = cp.FechaFin,
                                 ProductoId = pcp.ProductoId,
                                 MedidaId = pcp.MedidaId,
                                 NombreMedida = m.Nombre,
                                 FormaPago = pcp.FormaPago,
                                 Cantidad = pcp.Cantidad,
                                 PrecioCompra = pcp.PrecioCompra
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<ProductoCotizacionProveedorExtend> BuscarProductoCotizacionProveedor(int id)
        {
            using (var context = new BusinessContext())
            {
                var result = await (from pcp in context.ProductoCotizacionProveedores
                                    join cp in context.CotizacionProveedores on pcp.CotizacionProveedorId equals cp.CotizacionProveedorId
                                    join pro in context.Productos on pcp.ProductoId equals pro.ProductoId
                                    join m in context.Medidas on pcp.MedidaId equals m.MedidaId
                                    where pcp.ProductoCotizacionProveedorId == id
                                    select new ProductoCotizacionProveedorExtend()
                                    {
                                        ProductoCotizacionProveedorId = pcp.ProductoCotizacionProveedorId,
                                        ProductoId = pcp.ProductoId,
                                        ProveedorId = cp.ProveedorId,
                                        NombreProducto = pro.Nombre,
                                        MedidaId = pcp.MedidaId,
                                        NombreMedida = m.Nombre,
                                        FormaPago = pcp.FormaPago,
                                        Cantidad = pcp.Cantidad,
                                        PrecioCompra = pcp.PrecioCompra
                                    }).FirstOrDefaultAsync();
                return result;
            }
        }

        public async Task<IEnumerable<ProductoCotizacionProveedorExtend>> ListaProductosProveedor()
        {
            using (var context = new BusinessContext())
            {
                var result = from pcp in context.ProductoCotizacionProveedores
                             join cp in context.CotizacionProveedores on pcp.CotizacionProveedorId equals cp.CotizacionProveedorId
                             join prv in context.Proveedores on cp.ProveedorId equals prv.ProveedorId
                             join pro in context.Productos on pcp.ProductoId equals pro.ProductoId
                             group new { pcp.ProductoCotizacionProveedorId, pro.Nombre, prv.RazonSocial }
                             by new { pcp.ProductoCotizacionProveedorId, Nombre = pro.Nombre, RazonSocial = prv.RazonSocial } into g
                             select new ProductoCotizacionProveedorExtend()
                             {
                                 ProductoCotizacionProveedorId = g.Key.ProductoCotizacionProveedorId,
                                 NombreProducto = g.FirstOrDefault().Nombre,
                                 NombreProveedor = g.FirstOrDefault().RazonSocial
                             };
                return await result.ToListAsync();
            }
        }
    }
}
