using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IOrdenInventario<T> where T : class
    {
        Task<string> GenerarCodigo();
        Task<IEnumerable<OrdenInventarioExtend>> SelectOrdenesInventario(CriteriaOrdenInventario filter);
    }
}