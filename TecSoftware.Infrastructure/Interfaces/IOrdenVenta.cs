using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IOrdenVenta<T> where T : class
    {
        Task Actualizar(T entity);
        Task<string> CodigoNumerico();
        Task Registrar(T entity);
        Task<IEnumerable<UniversalExtend>> SelectOrdenesDeVenta(CriteriaOrdenVenta filter);
    }
}