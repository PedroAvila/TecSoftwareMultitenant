using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdProducto
    {
        Task AsignarColores(Producto producto, List<Colour> colores);
        Task AsignarProveedores(Producto producto, List<Proveedor> proveedores);
        Task AsignarTallas(Producto producto, List<Talla> tallas);
        Task AsignarTarifaImpuestos(Producto producto, List<TasaImpuesto> tImpuestos);
        Task<IEnumerable<ProductoExtend>> BuscarProducto(CriteriaProducto filter);
        Task<ProductoExtend> BuscarXCodigo(string valor);
        decimal CalcularUtilidad(decimal utilidad, decimal precioCompra);
        Task Create(Producto entity);
        Task Delete(Expression<Func<Producto, bool>> predicate);
        decimal ObtenerPrecioBasae(int id);
        Task<IEnumerable<ProductoExtend>> ProductoMasRentable(DateTime desde, DateTime hasta);
        Task<IEnumerable<ProductoExtend>> ProductoMasVendido(DateTime desde, DateTime hasta);
        Task<IEnumerable<ProductoExtend>> ProductoSinMovimiento(DateTime desde, DateTime hasta);
        Task RemoveColores(Producto producto, List<Colour> colores);
        Task RemoveProveedores(Producto producto, List<Proveedor> proveedores);
        Task RemoveTallas(Producto producto, List<Talla> tallas);
        Task RemoveTarifaImpuestos(Producto producto, List<TasaImpuesto> tImpuestos);
        Task<IEnumerable<UniversalExtend>> SearchProduct(string valor);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Producto, bool>> predicate, Expression<Func<Producto, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Producto, UniversalExtend>> source);
        Task<Producto> Single(Expression<Func<Producto, bool>> predicate);
        Task<Producto> Single(Expression<Func<Producto, bool>> predicate, List<Expression<Func<Producto, object>>> includes);
        Task<List<ICollection<TasaImpuesto>>> TasaImpuestosXProducto(int id);
    }
}