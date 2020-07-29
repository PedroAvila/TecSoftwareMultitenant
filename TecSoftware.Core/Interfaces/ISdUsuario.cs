using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdUsuario
    {
        Task<bool> Autentificar(Usuario entity);
        Task Create(Usuario entity);
        Task Delete(Expression<Func<Usuario, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Usuario, bool>> predicate, Expression<Func<Usuario, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Usuario, UniversalExtend>> source);
        Task<Usuario> Single(Expression<Func<Usuario, bool>> predicate);
        Task<Usuario> Single(Expression<Func<Usuario, bool>> predicate, List<Expression<Func<Usuario, object>>> includes);
        Task UpdatePassword(Usuario entity);
    }
}