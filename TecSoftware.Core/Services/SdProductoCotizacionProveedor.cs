using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProductoCotizacionProveedor : ISdProductoCotizacionProveedor
    {
        private readonly ProductoCotizacionProveedorRepository _productoCotizacionProveedorRepository =
            new ProductoCotizacionProveedorRepository();
        public async Task<IEnumerable<CotizacionProveedorExtend>> BuscarCotizacionesXProducto(int producto)
        {
            return await _productoCotizacionProveedorRepository.BuscarCotizacionesXProducto(producto);
        }

        public async Task<IEnumerable<ProductoCotizacionProveedorExtend>> ListaProductosProveedor()
        {
            return await _productoCotizacionProveedorRepository.ListaProductosProveedor();
        }

        public async Task<ProductoCotizacionProveedorExtend> BuscarProductoCotizacionProveedor(int id)
        {
            return await _productoCotizacionProveedorRepository.BuscarProductoCotizacionProveedor(id);
        }

        public void Agregar(ProductoCotizacionProveedorExtend entity)
        {
            _productoCotizacionProveedorRepository.Agregar(entity);
        }

        public List<ProductoCotizacionProveedorExtend> MostrarDetalle()
        {
            return _productoCotizacionProveedorRepository.DetalleItemTemp;
        }

        public void Remove(int id)
        {
            _productoCotizacionProveedorRepository.Remove(id);
        }
    }
}
