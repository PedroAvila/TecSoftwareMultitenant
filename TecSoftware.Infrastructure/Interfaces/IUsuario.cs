using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IUsuario<T> where T : class
    {
        Task UpdateUser(T entity);
        Task<bool> Autentificar(Usuario entity);
        Task UpdatePassword(Usuario entity);
    }
}
