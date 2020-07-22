using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IRequerimientoCompra<T> where T : class
    {
        Task<string> GenerarCodigo();
        Task<IEnumerable<UniversalExtend>> SelectRequerimientoCompra(CriteriaDocumento filter);
    }
}