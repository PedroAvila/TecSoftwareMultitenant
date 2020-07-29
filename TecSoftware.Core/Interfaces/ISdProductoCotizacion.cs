using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdProductoCotizacion
    {
        Task Create(ProductoCotizacion entity);
        Task Delete(Expression<Func<ProductoCotizacion, bool>> predicate);
        Task<IEnumerable<ProductoCotizacionExtend>> ListaProductoCotizacion(int id);
        Task<int> ObtenerIdProductoCotizacion(string numeroCotizacion, int productoId);
        Task<ProductoCotizacion> Single(Expression<Func<ProductoCotizacion, bool>> predicate);
    }
}