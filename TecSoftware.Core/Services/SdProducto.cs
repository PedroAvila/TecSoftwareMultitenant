using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProducto
    {
        private readonly ProductoRepository _productoRepository = new ProductoRepository();
        private readonly ProductoValidator _productoValidator = new ProductoValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Producto, UniversalExtend>> source)
        {
            return _productoRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList
            (Expression<Func<Producto, bool>> predicate, Expression<Func<Producto, UniversalExtend>> source)
        {
            return _productoRepository.SelectList(predicate, source);
        }

        public Producto Single(Expression<Func<Producto, bool>> predicate)
        {
            return _productoRepository.Single(predicate);
        }

        public Producto Single(Expression<Func<Producto, bool>> predicate,
            List<Expression<Func<Producto, object>>> includes)
        {
            return _productoRepository.Single(predicate, includes);
        }

        public ProductoExtend BuscarXCodigo(string valor)
        {
            return _productoRepository.BuscarXCodigo(valor);
        }


        public void Create(Producto entity)
        {
            var result = _productoValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.ProductoId != default(int))
                _productoRepository.Update(entity);
            else
            {
                bool exist = _productoRepository.Exist(x => x.Nombre == entity.Nombre && x.MarcaId == entity.MarcaId);
                if (exist)
                    throw new CustomException("El Producto, que intenta registrar ya existe.");
                entity.Codigo = _productoRepository.GenerarCodigo();
                _productoRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Producto, bool>> predicate)
        {
            _productoRepository.Delete(predicate);
        }

        public void AsignarTarifaImpuestos(Producto producto, List<TasaImpuesto> tImpuestos)
        {
            _productoRepository.AsignarTarifaImpuestos(producto, tImpuestos);
        }

        public void RemoveTarifaImpuestos(Producto producto, List<TasaImpuesto> tImpuestos)
        {
            _productoRepository.RemoveTarifaImpuestos(producto, tImpuestos);
        }

        public List<ICollection<TasaImpuesto>> TasaImpuestosXProducto(int id)
        {
            return _productoRepository.TasaImpuestosXProducto(id);
        }

        public decimal CalcularUtilidad(decimal utilidad, decimal precioCompra)
        {
            var porcentaje = utilidad / 100M;
            var precioBase = precioCompra + (precioCompra * porcentaje);
            return precioBase;
        }

        public decimal ObtenerPrecioBasae(int id)
        {
            return _productoRepository.ObtenerPrecioBasae(id);
        }

        public void AsignarTallas(Producto producto, List<Talla> tallas)
        {
            _productoRepository.AsignarTallas(producto, tallas);
        }
        public void RemoveTallas(Producto producto, List<Talla> tallas)
        {
            _productoRepository.RemoveTallas(producto, tallas);
        }

        public void AsignarColores(Producto producto, List<Colour> colores)
        {
            _productoRepository.AsignarColores(producto, colores);
        }

        public void RemoveColores(Producto producto, List<Colour> colores)
        {
            _productoRepository.RemoveColores(producto, colores);
        }

        public void AsignarProveedores(Producto producto, List<Proveedor> proveedores)
        {
            _productoRepository.AsignarProveedores(producto, proveedores);
        }

        public void RemoveProveedores(Producto producto, List<Proveedor> proveedores)
        {
            _productoRepository.RemoveProveedores(producto, proveedores);
        }

        public IEnumerable<UniversalExtend> SearchProduct(string valor)
        {
            return _productoRepository.SearchProduct(valor);
        }

        public IEnumerable<ProductoExtend> BuscarProducto(CriteriaProducto filter)
        {
            return _productoRepository.BuscarProducto(filter);
        }

        public IEnumerable<ProductoExtend> ProductoMasVendido(DateTime desde, DateTime hasta)
        {
            return _productoRepository.ProductoMasVendido(desde, hasta);
        }

        public IEnumerable<ProductoExtend> ProductoMasRentable(DateTime desde, DateTime hasta)
        {
            return _productoRepository.ProductoMasRentable(desde, hasta);
        }

        public IEnumerable<ProductoExtend> ProductoSinMovimiento(DateTime desde, DateTime hasta)
        {
            return _productoRepository.ProductoSinMovimiento(desde, hasta);
        }
    }
}
