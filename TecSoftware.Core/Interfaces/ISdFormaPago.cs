using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdFormaPago
    {
        Task Create(FormaPago entity);
        Task Delete(Expression<Func<FormaPago, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<FormaPago, UniversalExtend>> source);
        Task<FormaPago> Single(Expression<Func<FormaPago, bool>> predicate);
    }
}