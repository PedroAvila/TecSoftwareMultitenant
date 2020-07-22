using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdUsuario
    {
        Task UpdateUser(Usuario entity);
        Task<bool> Autentificar(Usuario entity);
    }
}
