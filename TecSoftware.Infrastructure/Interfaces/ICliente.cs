using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface ICliente<T> where T : class
    {
        Task<IEnumerable<UniversalExtend>> ListaClienteXCodigo(Criteria filter);
    }
}
