using System.Threading.Tasks;

namespace TecSoftware.Infrastructure
{
    public interface IOperacion<T> where T : class
    {
        Task<bool> ValidarOperacion(int puntoEmision);
        Task<bool> VerificarRegistro();
    }
}