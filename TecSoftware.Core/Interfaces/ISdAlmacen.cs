using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdAlmacen
    {
        Task Create(Almacen entity);
        Task Delete(Expression<Func<Almacen, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListarBodega(Expression<Func<Almacen, bool>> predicate, Expression<Func<Almacen, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Almacen, bool>> predicate, Expression<Func<Almacen, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Almacen, UniversalExtend>> source);
        Task<Almacen> Single(Expression<Func<Almacen, bool>> predicate);
    }
}