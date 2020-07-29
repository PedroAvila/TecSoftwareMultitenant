using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdPresentacion
    {
        Task Create(Presentacion entity);
        Task<IEnumerable<UniversalExtend>> ListaPresentacion(Expression<Func<Presentacion, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Presentacion, bool>> predicate, Expression<Func<Presentacion, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Presentacion, UniversalExtend>> source);
        Task<Presentacion> Single(Expression<Func<Presentacion, bool>> predicate);
    }
}