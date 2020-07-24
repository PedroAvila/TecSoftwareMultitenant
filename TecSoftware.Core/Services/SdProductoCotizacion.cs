using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProductoCotizacion
    {
        private readonly ProductoCotizacionRepository _productoCotizacionRepository = new ProductoCotizacionRepository();
        private readonly ProductoCotizacionValidator _productoCotizacionValidator = new ProductoCotizacionValidator();

        public ProductoCotizacion Single(Expression<Func<ProductoCotizacion, bool>> predicate)
        {
            return _productoCotizacionRepository.Single(predicate);
        }

        public void Create(ProductoCotizacion entity)
        {
            var result = _productoCotizacionValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.ProductoCotizacionId != default)
                _productoCotizacionRepository.Update(entity);
            else
            {
                bool exist = _productoCotizacionRepository.Exist(x => x.ProductoCotizacionId == entity.ProductoCotizacionId);
                if (exist)
                    throw new CustomException("El Producto de Cotización que intenta registrar ya existe.");
                _productoCotizacionRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<ProductoCotizacion, bool>> predicate)
        {
            _productoCotizacionRepository.Delete(predicate);
        }

        public IEnumerable<ProductoCotizacionExtend> ListaProductoCotizacion(int id)
        {
            return _productoCotizacionRepository.ListaProductoCotizacion(id);
        }

        public int ObtenerIdProductoCotizacion(string numeroCotizacion, int productoId)
        {
            return _productoCotizacionRepository.ObtenerIdProductoCotizacion(numeroCotizacion, productoId);
        }
    }
}
