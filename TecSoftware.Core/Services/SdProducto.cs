using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProducto : ISdProducto
    {
        private readonly ProductoRepository _productoRepository = new ProductoRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Producto, UniversalExtend>> source)
        {
            return await _productoRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<Producto, bool>> predicate, Expression<Func<Producto, UniversalExtend>> source)
        {
            return await _productoRepository.SelectList(predicate, source);
        }

        public async Task<Producto> Single(Expression<Func<Producto, bool>> predicate)
        {
            return await _productoRepository.Single(predicate);
        }

        public async Task<Producto> Single(Expression<Func<Producto, bool>> predicate,
            List<Expression<Func<Producto, object>>> includes)
        {
            return await _productoRepository.Single(predicate, includes);
        }

        public async Task<ProductoExtend> BuscarXCodigo(string valor)
        {
            return await _productoRepository.BuscarXCodigo(valor);
        }

        public async Task Create(Producto entity)
        {

            if (entity.ProductoId != default(int))
                await _productoRepository.Update(entity);
            else
            {
                bool exist = await _productoRepository.Exist(x => x.Nombre == entity.Nombre && x.MarcaId == entity.MarcaId);
                if (exist)
                    throw new CustomException("El Producto, que intenta registrar ya existe.");
                entity.Codigo = await _productoRepository.GenerarCodigo();
                await _productoRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Producto, bool>> predicate)
        {
            await _productoRepository.Delete(predicate);
        }

        public async Task AsignarTarifaImpuestos(Producto producto, List<TasaImpuesto> tImpuestos)
        {
            await _productoRepository.AsignarTarifaImpuestos(producto, tImpuestos);
        }

        public async Task RemoveTarifaImpuestos(Producto producto, List<TasaImpuesto> tImpuestos)
        {
            await _productoRepository.RemoveTarifaImpuestos(producto, tImpuestos);
        }

        public async Task<List<ICollection<TasaImpuesto>>> TasaImpuestosXProducto(int id)
        {
            return await _productoRepository.TasaImpuestosXProducto(id);
        }

        public decimal CalcularUtilidad(decimal utilidad, decimal precioCompra)
        {
            var porcentaje = utilidad / 100M;
            var precioBase = precioCompra + (precioCompra * porcentaje);
            return precioBase;
        }

        /// <summary>
        /// Creo que no lo uso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public decimal ObtenerPrecioBasae(int id)
        {
            return _productoRepository.ObtenerPrecioBasae(id);
        }

        public async Task AsignarTallas(Producto producto, List<Talla> tallas)
        {
            await _productoRepository.AsignarTallas(producto, tallas);
        }
        public async Task RemoveTallas(Producto producto, List<Talla> tallas)
        {
            await _productoRepository.RemoveTallas(producto, tallas);
        }

        public async Task AsignarColores(Producto producto, List<Colour> colores)
        {
            await _productoRepository.AsignarColores(producto, colores);
        }

        public async Task RemoveColores(Producto producto, List<Colour> colores)
        {
            await _productoRepository.RemoveColores(producto, colores);
        }

        public async Task AsignarProveedores(Producto producto, List<Proveedor> proveedores)
        {
            await _productoRepository.AsignarProveedores(producto, proveedores);
        }

        public async Task RemoveProveedores(Producto producto, List<Proveedor> proveedores)
        {
            await _productoRepository.RemoveProveedores(producto, proveedores);
        }

        public async Task<IEnumerable<UniversalExtend>> SearchProduct(string valor)
        {
            return await _productoRepository.SearchProduct(valor);
        }

        public async Task<IEnumerable<ProductoExtend>> BuscarProducto(CriteriaProducto filter)
        {
            return await _productoRepository.BuscarProducto(filter);
        }

        public async Task<IEnumerable<ProductoExtend>> ProductoMasVendido(DateTime desde, DateTime hasta)
        {
            return await _productoRepository.ProductoMasVendido(desde, hasta);
        }

        public async Task<IEnumerable<ProductoExtend>> ProductoMasRentable(DateTime desde, DateTime hasta)
        {
            return await _productoRepository.ProductoMasRentable(desde, hasta);
        }

        public async Task<IEnumerable<ProductoExtend>> ProductoSinMovimiento(DateTime desde, DateTime hasta)
        {
            return await _productoRepository.ProductoSinMovimiento(desde, hasta);
        }
    }
}
