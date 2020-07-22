using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IProductoCotizacion<T> where T : class
    {
        Task<IEnumerable<ProductoCotizacionExtend>> ListaProductoCotizacion(int id);
        Task<int> ObtenerIdProductoCotizacion(string numeroCotizacion, int productoId);
    }
}