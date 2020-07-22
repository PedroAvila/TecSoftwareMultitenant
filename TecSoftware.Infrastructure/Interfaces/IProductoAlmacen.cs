using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IProductoAlmacen<T> where T : class
    {
        Task<IEnumerable<ProductoAlmacenExtend>> ListaProductoAlmacen(int id);
        Task UpdateProductoAlmacen(int producto, int almacen, decimal saldo);
    }
}