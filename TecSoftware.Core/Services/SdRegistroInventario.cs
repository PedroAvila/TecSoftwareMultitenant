using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public class SdRegistroInventario : ISdRegistroInventario
    {
        private readonly SdProductoAlmacen _sdProductoAlmacen = new SdProductoAlmacen();
        public async Task ActualizarSaldosCostos(RegistroInventario registroInventario, ProductoOrdenInventario productoOrdenInventario)
        {
            await _sdProductoAlmacen.ActualizarSaldosCostos(registroInventario, productoOrdenInventario);
        }
    }
}
