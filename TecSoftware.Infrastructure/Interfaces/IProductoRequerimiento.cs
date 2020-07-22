using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IProductoRequerimiento<T> where T : class
    {
        Task<IEnumerable<ProductoRequerimientoExtend>> ListaProductoRequerimiento(int id);
        Task<IEnumerable<UniversalExtend>> SelectProductoRequerimiento(CriteriaDocumento filter);
    }
}