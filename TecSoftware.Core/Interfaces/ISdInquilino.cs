using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdInquilino
    {
        Task<Inquilino> Single(Expression<Func<Inquilino, bool>> predicate, List<Expression<Func<Inquilino, object>>> includes);
        Task Create(Inquilino entity);
    }
}
