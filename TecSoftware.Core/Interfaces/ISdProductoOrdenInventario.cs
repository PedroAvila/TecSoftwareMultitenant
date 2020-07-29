using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdProductoOrdenInventario
    {
        Task Create(ProductoOrdenInventario entity);
        Task Delete(Expression<Func<ProductoOrdenInventario, bool>> predicate);
        Task<IEnumerable<ProductoOrdenInventarioExtend>> ListaProductoOrdenInventario(int id);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<ProductoOrdenInventario, bool>> predicate, Expression<Func<ProductoOrdenInventario, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<ProductoOrdenInventario, UniversalExtend>> source);
        Task<IEnumerable<ProductoOrdenInventarioExtend>> SelectProductoOrdenesInventario(CriteriaProductoOrdenInventario filter);
        Task<ProductoOrdenInventario> Single(Expression<Func<ProductoOrdenInventario, bool>> predicate);
        Task<ProductoOrdenInventario> Single(Expression<Func<ProductoOrdenInventario, bool>> predicate, List<Expression<Func<ProductoOrdenInventario, object>>> includes);
    }
}