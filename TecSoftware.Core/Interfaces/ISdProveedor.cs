using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdProveedor
    {
        void Agregar(Proveedor entity);
        void CleanProveedor();
        Task Create(Proveedor entity);
        Task Delete(Expression<Func<Proveedor, bool>> predicate);
        List<Proveedor> MostrarProveedores();
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Proveedor, bool>> predicate, Expression<Func<Proveedor, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Proveedor, UniversalExtend>> source);
        Task<Proveedor> Single(Expression<Func<Proveedor, bool>> predicate);
    }
}