using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProductoCotizacion
    {
        private readonly ProductoCotizacionRepository _productoCotizacionRepository = new ProductoCotizacionRepository();

        public async Task<ProductoCotizacion> Single(Expression<Func<ProductoCotizacion, bool>> predicate)
        {
            return await _productoCotizacionRepository.Single(predicate);
        }

        public async Task Create(ProductoCotizacion entity)
        {

            if (entity.ProductoCotizacionId != default)
                await _productoCotizacionRepository.Update(entity);
            else
            {
                bool exist = await _productoCotizacionRepository.Exist(x => x.ProductoCotizacionId == entity.ProductoCotizacionId);
                if (exist)
                    throw new CustomException("El Producto de Cotización que intenta registrar ya existe.");
                await _productoCotizacionRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<ProductoCotizacion, bool>> predicate)
        {
            await _productoCotizacionRepository.Delete(predicate);
        }

        public async Task<IEnumerable<ProductoCotizacionExtend>> ListaProductoCotizacion(int id)
        {
            return await _productoCotizacionRepository.ListaProductoCotizacion(id);
        }

        public async Task<int> ObtenerIdProductoCotizacion(string numeroCotizacion, int productoId)
        {
            return await _productoCotizacionRepository.ObtenerIdProductoCotizacion(numeroCotizacion, productoId);
        }
    }
}
