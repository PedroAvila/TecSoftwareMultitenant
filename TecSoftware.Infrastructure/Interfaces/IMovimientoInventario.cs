using System.Threading.Tasks;

namespace TecSoftware.Infrastructure
{
    public interface IMovimientoInventario<T> where T : class
    {
        Task<decimal> ObtenerCantidadSaldoFinal(int producto);
    }
}