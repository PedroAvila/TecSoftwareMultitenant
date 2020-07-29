using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdRol
    {
        Task AsignarFunciones(Rol rol, List<Funcion> funciones);
        Task Create(Rol entity);
        Task Delete(Expression<Func<Rol, bool>> predicate);
        Task<IEnumerable<Rol>> Filter(Expression<Func<Rol, bool>> predicate, List<Expression<Func<Rol, object>>> includes);
        Task<IEnumerable<UniversalExtend>> ListaRoles(Expression<Func<Rol, UniversalExtend>> source);
        Task RemoveFunciones(Rol rol, List<Funcion> funciones);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Rol, UniversalExtend>> source);
        Task<Rol> Single(Expression<Func<Rol, bool>> predicate);
        Task<Rol> Single(Expression<Func<Rol, bool>> predicate, List<Expression<Func<Rol, object>>> includes);
    }
}