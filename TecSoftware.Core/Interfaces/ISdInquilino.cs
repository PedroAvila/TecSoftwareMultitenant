using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdInquilino
    {
        Task Create(Inquilino entity);
    }
}
