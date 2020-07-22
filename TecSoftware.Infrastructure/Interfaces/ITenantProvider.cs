using System.Collections.Generic;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface ITenantProvider
    {
        List<Conexion> GetConexions();
        string GetName();
    }
}
