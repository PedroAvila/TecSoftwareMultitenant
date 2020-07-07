using System.Threading.Tasks;

namespace TecSoftware.Core
{
    public interface IService
    {
        Task ObtenerTenant(string tenant);
    }
}
