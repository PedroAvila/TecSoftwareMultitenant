using System.Threading.Tasks;

namespace TecSoftware.Infrastructure
{
    public interface INumerador<T> where T : class
    {
        Task<string> NumeroSecuencial(int puntoEmision, int comprobante);
        Task UpdateNumerador(T entity);
    }
}