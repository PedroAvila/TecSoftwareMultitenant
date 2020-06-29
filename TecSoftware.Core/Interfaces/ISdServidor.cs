using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdServidor
    {
        Task Create(Servidor entity);
    }
}
