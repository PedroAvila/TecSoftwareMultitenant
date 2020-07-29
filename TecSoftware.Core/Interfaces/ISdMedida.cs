using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdMedida
    {
        Task Create(Medida entity);
        Task Delete(Expression<Func<Medida, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaMedida(Expression<Func<Medida, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Medida, UniversalExtend>> source);
        Task<Medida> Single(Expression<Func<Medida, bool>> predicate);
    }
}