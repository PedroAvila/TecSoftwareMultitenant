using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProductoRequerimiento
    {
        private readonly ProductoRequerimientoRepository _productoRequerimientoRepository = new ProductoRequerimientoRepository();
        private readonly ProductoRequerimientoValidator _productoRequerimientoValidator = new ProductoRequerimientoValidator();

        public ProductoRequerimiento Single(Expression<Func<ProductoRequerimiento, bool>> predicate)
        {
            return _productoRequerimientoRepository.Single(predicate);
        }

        public ProductoRequerimiento Single(Expression<Func<ProductoRequerimiento, bool>> predicate,
            List<Expression<Func<ProductoRequerimiento, object>>> includes)
        {
            return _productoRequerimientoRepository.Single(predicate, includes);
        }

        public void Create(ProductoRequerimiento entity)
        {
            var result = _productoRequerimientoValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.ProductoRequerimientoId != default)
                _productoRequerimientoRepository.Update(entity);
            else
            {
                bool exist = _productoRequerimientoRepository.Exist(x => x.ProductoRequerimientoId == entity.ProductoRequerimientoId);
                if (exist)
                    throw new CustomException("El Producto de Requerimiento que intenta registrar ya existe.");
                _productoRequerimientoRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<ProductoRequerimiento, bool>> predicate)
        {
            _productoRequerimientoRepository.Delete(predicate);
        }

        public IEnumerable<ProductoRequerimientoExtend> ListaProductoRequerimiento(int id)
        {
            return _productoRequerimientoRepository.ListaProductoRequerimiento(id);
        }

        public IEnumerable<UniversalExtend> SelectProductoRequerimiento(CriteriaDocumento filter)
        {
            return _productoRequerimientoRepository.SelectProductoRequerimiento(filter);
        }
    }
}
