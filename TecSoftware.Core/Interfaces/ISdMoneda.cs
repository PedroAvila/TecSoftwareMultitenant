using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdMoneda
    {
        Task Create(Moneda entity);
        Task Delete(Expression<Func<Moneda, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaMonedas(Expression<Func<Moneda, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Moneda, UniversalExtend>> source);
        Task<Moneda> Single(Expression<Func<Moneda, bool>> predicate);
    }
}