using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdOrdenCompra
    {
        Task<IEnumerable<OrdenCompraExtend>> ListarOrdenCompra(int ordenCompraId);
        Task Registrar(OrdenCompra entity);
        Task<OrdenCompra> Single(Expression<Func<OrdenCompra, bool>> predicate, List<Expression<Func<OrdenCompra, object>>> includes);
    }
}