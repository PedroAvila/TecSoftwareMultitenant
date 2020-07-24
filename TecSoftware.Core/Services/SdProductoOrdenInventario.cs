using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProductoOrdenInventario
    {
        private readonly ProductoOrdenInventarioRepository _productoOrdenInventarioRepository
            = new ProductoOrdenInventarioRepository();
        private readonly ProductoOrdenInventarioValidator _productoOrdenInventarioValidator
            = new ProductoOrdenInventarioValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<ProductoOrdenInventario, UniversalExtend>> source)
        {
            return _productoOrdenInventarioRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList
            (Expression<Func<ProductoOrdenInventario, bool>> predicate, Expression<Func<ProductoOrdenInventario, UniversalExtend>> source)
        {
            return _productoOrdenInventarioRepository.SelectList(predicate, source);
        }

        public ProductoOrdenInventario Single(Expression<Func<ProductoOrdenInventario, bool>> predicate)
        {
            return _productoOrdenInventarioRepository.Single(predicate);
        }

        public ProductoOrdenInventario Single(Expression<Func<ProductoOrdenInventario, bool>> predicate,
            List<Expression<Func<ProductoOrdenInventario, object>>> includes)
        {
            return _productoOrdenInventarioRepository.Single(predicate, includes);
        }

        public void ValidarEntidad(ProductoOrdenInventario entity)
        {
            var result = _productoOrdenInventarioValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
        }

        public void Create(ProductoOrdenInventario entity)
        {
            var result = _productoOrdenInventarioValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.ProductoOrdenInventarioId != default)
                _productoOrdenInventarioRepository.Update(entity);
            else
            {
                bool exist = _productoOrdenInventarioRepository.Exist(x => x.ProductoOrdenInventarioId == entity.ProductoOrdenInventarioId);
                if (exist)
                    throw new CustomException("El número de documento que intenta registrar ya existe.");
                _productoOrdenInventarioRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<ProductoOrdenInventario, bool>> predicate)
        {
            _productoOrdenInventarioRepository.Delete(predicate);
        }

        public IEnumerable<ProductoOrdenInventarioExtend> ListaProductoOrdenInventario(int id)
        {
            return _productoOrdenInventarioRepository.ListaProductoOrdenInventario(id);
        }

        /// <summary>
        /// Método para buscar Producto Ordenes de Inventario
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<ProductoOrdenInventarioExtend> SelectProductoOrdenesInventario
            (CriteriaProductoOrdenInventario filter)
        {
            return _productoOrdenInventarioRepository.SelectProductoOrdenesInventario(filter);
        }
    }
}
