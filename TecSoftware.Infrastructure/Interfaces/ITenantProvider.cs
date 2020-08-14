using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface ITenantProvider
    {
        Task<IEnumerable<Conexion>> MostrarConexiones();
        Task<string> GetName();
    }
}
