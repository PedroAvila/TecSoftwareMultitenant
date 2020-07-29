using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdProductoRequerimiento
    {
        Task Create(ProductoRequerimiento entity);
        Task Delete(Expression<Func<ProductoRequerimiento, bool>> predicate);
        Task<IEnumerable<ProductoRequerimientoExtend>> ListaProductoRequerimiento(int id);
        Task<IEnumerable<UniversalExtend>> SelectProductoRequerimiento(CriteriaDocumento filter);
        Task<ProductoRequerimiento> Single(Expression<Func<ProductoRequerimiento, bool>> predicate);
        Task<ProductoRequerimiento> Single(Expression<Func<ProductoRequerimiento, bool>> predicate, List<Expression<Func<ProductoRequerimiento, object>>> includes);
    }
}