using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdOperacionMovimiento
    {
        Task Create(OperacionMovimiento entity);
    }
}