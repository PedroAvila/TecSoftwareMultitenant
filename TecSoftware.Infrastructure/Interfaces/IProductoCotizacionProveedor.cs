using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IProductoCotizacionProveedor<T> where T : class
    {
        List<ProductoCotizacionProveedorExtend> DetalleItemTemp { get; }

        void Agregar(ProductoCotizacionProveedorExtend entity);
        Task<IEnumerable<CotizacionProveedorExtend>> BuscarCotizacionesXProducto(int producto);
        Task<ProductoCotizacionProveedorExtend> BuscarProductoCotizacionProveedor(int id);
        Task<IEnumerable<ProductoCotizacionProveedorExtend>> ListaProductosProveedor();
        void Remove(int id);
    }
}