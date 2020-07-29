using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdCategoria
    {
        Task Create(Categoria entity);
        Task Delete(Expression<Func<Categoria, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaCategoria(Expression<Func<Categoria, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Categoria, UniversalExtend>> source);
        Task<Categoria> Single(Expression<Func<Categoria, bool>> predicate);
    }
}