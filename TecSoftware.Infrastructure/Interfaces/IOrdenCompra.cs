using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IOrdenCompra<T> where T : class
    {
        Task<string> GenerarCodigo();
        Task<IEnumerable<OrdenCompraExtend>> ListarOrdenCompra(int ordenCompraId);
        Task Registrar(T entity);
    }
}