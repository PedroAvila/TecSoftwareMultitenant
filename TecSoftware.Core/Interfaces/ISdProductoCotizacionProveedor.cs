using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdProductoCotizacionProveedor
    {
        void Agregar(ProductoCotizacionProveedorExtend entity);
        Task<IEnumerable<CotizacionProveedorExtend>> BuscarCotizacionesXProducto(int producto);
        Task<ProductoCotizacionProveedorExtend> BuscarProductoCotizacionProveedor(int id);
        Task<IEnumerable<ProductoCotizacionProveedorExtend>> ListaProductosProveedor();
        List<ProductoCotizacionProveedorExtend> MostrarDetalle();
        void Remove(int id);
    }
}