using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdListaPrecio
    {
        Task Create(ListaPrecio entity);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<ListaPrecio, UniversalExtend>> source);
        Task<ListaPrecio> Single(Expression<Func<ListaPrecio, bool>> predicate);
    }
}