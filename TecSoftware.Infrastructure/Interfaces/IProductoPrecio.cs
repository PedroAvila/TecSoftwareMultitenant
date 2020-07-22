using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IProductoPrecio<T> where T : class
    {
        Task<IEnumerable<ProductoPrecioExtend>> ListaProductoPrecio(int id);
    }
}