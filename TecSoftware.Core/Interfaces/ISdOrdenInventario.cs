using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdOrdenInventario
    {
        Task Create(OrdenInventario entity);
        Task Delete(Expression<Func<OrdenInventario, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<OrdenInventario, UniversalExtend>> source);
        Task<IEnumerable<OrdenInventarioExtend>> SelectOrdenesInventario(CriteriaOrdenInventario filter);
        Task<OrdenInventario> Single(Expression<Func<OrdenInventario, bool>> predicate);
        Task<OrdenInventario> Single(Expression<Func<OrdenInventario, bool>> predicate, List<Expression<Func<OrdenInventario, object>>> includes);
    }
}