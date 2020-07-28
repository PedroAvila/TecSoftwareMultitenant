using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProductoRequerimiento
    {
        private readonly ProductoRequerimientoRepository _productoRequerimientoRepository =
            new ProductoRequerimientoRepository();

        public async Task<ProductoRequerimiento> Single(Expression<Func<ProductoRequerimiento, bool>> predicate)
        {
            return await _productoRequerimientoRepository.Single(predicate);
        }

        public async Task<ProductoRequerimiento> Single(Expression<Func<ProductoRequerimiento, bool>> predicate,
            List<Expression<Func<ProductoRequerimiento, object>>> includes)
        {
            return await _productoRequerimientoRepository.Single(predicate, includes);
        }

        public async Task Create(ProductoRequerimiento entity)
        {
            if (entity.ProductoRequerimientoId != default)
                await _productoRequerimientoRepository.Update(entity);
            else
            {
                bool exist = await _productoRequerimientoRepository
                    .Exist(x => x.ProductoRequerimientoId == entity.ProductoRequerimientoId);
                if (exist)
                    throw new CustomException("El Producto de Requerimiento que intenta registrar ya existe.");
                await _productoRequerimientoRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<ProductoRequerimiento, bool>> predicate)
        {
            await _productoRequerimientoRepository.Delete(predicate);
        }

        public async Task<IEnumerable<ProductoRequerimientoExtend>> ListaProductoRequerimiento(int id)
        {
            return await _productoRequerimientoRepository.ListaProductoRequerimiento(id);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectProductoRequerimiento(CriteriaDocumento filter)
        {
            return await _productoRequerimientoRepository.SelectProductoRequerimiento(filter);
        }
    }
}
