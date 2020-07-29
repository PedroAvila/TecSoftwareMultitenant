using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdRegistroInventario
    {
        Task ActualizarSaldosCostos(RegistroInventario registroInventario, ProductoOrdenInventario productoOrdenInventario);
    }
}