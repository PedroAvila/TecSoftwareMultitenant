using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdEstablecimiento
    {
        Task Create(Establecimiento entity);
        Task Delete(Expression<Func<Establecimiento, bool>> predicate);
        IEnumerable<Establecimiento> GetAll();
        Task<IEnumerable<UniversalExtend>> ListaEstablecimientos(Expression<Func<Establecimiento, bool>> predicate, Expression<Func<Establecimiento, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> ListaEstablecimientos(Expression<Func<Establecimiento, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> ListaTodoEstablecimientos(Expression<Func<Establecimiento, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Establecimiento, bool>> predicate, Expression<Func<Establecimiento, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Establecimiento, UniversalExtend>> source);
        Task<Establecimiento> Single(Expression<Func<Establecimiento, bool>> predicate);
    }
}