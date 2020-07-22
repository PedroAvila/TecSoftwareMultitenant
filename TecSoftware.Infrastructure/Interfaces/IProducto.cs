using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IProducto<T> where T : class
    {
        //void Actualizar(T entity);
        Task AsignarColores(T producto, List<Colour> colores);
        Task AsignarProveedores(T producto, List<Proveedor> proveedores);
        Task AsignarTallas(T producto, List<Talla> tallas);
        Task AsignarTarifaImpuestos(T producto, List<TasaImpuesto> tImpuestos);
        Task<IEnumerable<ProductoExtend>> BuscarProducto(CriteriaProducto filter);
        Task<ProductoExtend> BuscarXCodigo(string valor);
        Task<string> GenerarCodigo();
        //decimal ObtenerPrecioBasae(int id);
        Task<IEnumerable<ProductoExtend>> ProductoMasRentable(DateTime desde, DateTime hasta);
        Task<IEnumerable<ProductoExtend>> ProductoMasVendido(DateTime desde, DateTime hasta);
        Task<IEnumerable<ProductoExtend>> ProductoSinMovimiento(DateTime desde, DateTime hasta);
        //void Registrar(T entity);
        Task RemoveColores(T producto, List<Colour> colores);
        Task RemoveProveedores(T producto, List<Proveedor> proveedores);
        Task RemoveTallas(T producto, List<Talla> tallas);
        Task RemoveTarifaImpuestos(T producto, List<TasaImpuesto> tImpuestos);
        Task<IEnumerable<UniversalExtend>> SearchProduct(string valor);
        Task<List<ICollection<TasaImpuesto>>> TasaImpuestosXProducto(int id);
    }
}