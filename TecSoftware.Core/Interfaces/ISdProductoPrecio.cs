using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdProductoPrecio
    {
        ProductoPrecio CalcularPrecioPvP(ProductoPrecio entity);
        ProductoPrecio CalcularPrecioUtilidad(ProductoPrecio entity);
        Task Create(ProductoPrecio entity);
        Task Delete(Expression<Func<ProductoPrecio, bool>> predicate);
        Task<bool> Exist(Expression<Func<ProductoPrecio, bool>> predicate);
        Task<IEnumerable<ProductoPrecio>> Filter(Expression<Func<ProductoPrecio, bool>> predicate);
        Task<IEnumerable<ProductoPrecioExtend>> ListaProductoPrecio(int id);
        Task<ProductoPrecio> Single(Expression<Func<ProductoPrecio, bool>> predicate, List<Expression<Func<ProductoPrecio, object>>> includes);
    }
}