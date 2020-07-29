using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdFuncion
    {
        Task Create(Funcion entity);
        Task Delete(Expression<Func<Funcion, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Funcion, UniversalExtend>> source);
        Task<Funcion> Single(Expression<Func<Funcion, bool>> predicate);
    }
}