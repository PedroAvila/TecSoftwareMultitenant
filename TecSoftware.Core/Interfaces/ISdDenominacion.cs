using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdDenominacion
    {
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Denominacion, bool>> predicate, Expression<Func<Denominacion, UniversalExtend>> source);
    }
}