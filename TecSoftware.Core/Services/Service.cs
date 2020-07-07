using System.Threading.Tasks;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class Service : IService
    {
        private readonly ServiceContextTenantProvider service = new ServiceContextTenantProvider();
        public async Task ObtenerTenant(string tenant)
        {
            await service.ObtenerTenant(tenant);
        }
    }
}
