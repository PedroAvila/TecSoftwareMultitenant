using System.Collections.Generic;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProductoCotizacionProveedor
    {
        private readonly ProductoCotizacionProveedorRepository _productoCotizacionProveedorRepository =
            new ProductoCotizacionProveedorRepository();
        public IEnumerable<CotizacionProveedorExtend> BuscarCotizacionesXProducto(int producto)
        {
            return _productoCotizacionProveedorRepository.BuscarCotizacionesXProducto(producto);
        }

        public IEnumerable<ProductoCotizacionProveedorExtend> ListaProductosProveedor()
        {
            return _productoCotizacionProveedorRepository.ListaProductosProveedor();
        }

        public ProductoCotizacionProveedorExtend BuscarProductoCotizacionProveedor(int id)
        {
            return _productoCotizacionProveedorRepository.BuscarProductoCotizacionProveedor(id);
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
