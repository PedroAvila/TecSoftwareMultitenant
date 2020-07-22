using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface IService
    {
        Task<InquilinoExtend> ObtenerTenant(string name);
    }
}
