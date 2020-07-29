using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdMovimientoInventario
    {
        Task Create(MovimientoInventario entity);
        Task<decimal> ObtenerCantidadSaldoFinal(int producto);
    }
}