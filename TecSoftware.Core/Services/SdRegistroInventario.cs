using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public class SdRegistroInventario
    {
        private readonly SdProductoAlmacen _sdProductoAlmacen = new SdProductoAlmacen();
        public void ActualizarSaldosCostos(RegistroInventario registroInventario, ProductoOrdenInventario productoOrdenInventario)
        {
            _sdProductoAlmacen.ActualizarSaldosCostos(registroInventario, productoOrdenInventario);

        }
    }
}
