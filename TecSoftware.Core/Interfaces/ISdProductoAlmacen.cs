using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdProductoAlmacen
    {
        Task ActualizarSaldosCostos(RegistroInventario registroInventario, ProductoOrdenInventario entity);
        Task Create(ProductoAlmacen entity);
        Task Delete(Expression<Func<ProductoAlmacen, bool>> predicate);
        Task<IEnumerable<ProductoAlmacenExtend>> ListaProductoAlmacen(int id);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<ProductoAlmacen, bool>> predicate, Expression<Func<ProductoAlmacen, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<ProductoAlmacen, UniversalExtend>> source);
        Task<ProductoAlmacen> Single(Expression<Func<ProductoAlmacen, bool>> predicate);
    }
}