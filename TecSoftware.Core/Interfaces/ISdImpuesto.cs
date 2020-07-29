using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdImpuesto
    {
        Task Create(Impuesto entity);
        Task Delete(Expression<Func<Impuesto, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaImpuestos(Expression<Func<Impuesto, bool>> predicate, Expression<Func<Impuesto, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Impuesto, bool>> predicate, Expression<Func<Impuesto, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Impuesto, UniversalExtend>> source);
        Task<Impuesto> Single(Expression<Func<Impuesto, bool>> predicate);
    }
}