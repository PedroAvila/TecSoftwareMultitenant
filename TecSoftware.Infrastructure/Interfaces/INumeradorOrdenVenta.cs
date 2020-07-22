using System.Threading.Tasks;

namespace TecSoftware.Infrastructure
{
    public interface INumeradorOrdenVenta<T> where T : class
    {
        Task<string> NumeroSecuencial(int puntoEmision);
        Task UpdateNumeradorOrdenVenta(T entity);
    }
}