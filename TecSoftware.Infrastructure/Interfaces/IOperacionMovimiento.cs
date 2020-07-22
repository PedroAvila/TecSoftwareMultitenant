using System.Threading.Tasks;

namespace TecSoftware.Infrastructure
{
    public interface IOperacionMovimiento<T> where T : class
    {
        Task Registrar(T entity);
    }
}