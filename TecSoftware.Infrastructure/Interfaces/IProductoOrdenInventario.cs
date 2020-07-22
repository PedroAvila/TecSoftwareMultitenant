using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IProductoOrdenInventario<T> where T : class
    {
        Task<IEnumerable<ProductoOrdenInventarioExtend>> ListaProductoOrdenInventario(int id);
        Task<IEnumerable<ProductoOrdenInventarioExtend>> SelectProductoOrdenesInventario
            (CriteriaProductoOrdenInventario filter);
    }
}