using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdSubCategoria
    {
        Task Create(SubCategoria entity);
        Task Delete(Expression<Func<SubCategoria, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaSubCategoria(Expression<Func<SubCategoria, bool>> predicate, Expression<Func<SubCategoria, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<SubCategoria, bool>> predicate, Expression<Func<SubCategoria, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<SubCategoria, UniversalExtend>> source);
        Task<SubCategoria> Single(Expression<Func<SubCategoria, bool>> predicate);
    }
}