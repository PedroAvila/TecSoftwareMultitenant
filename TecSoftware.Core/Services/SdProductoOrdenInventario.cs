using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProductoOrdenInventario : ISdProductoOrdenInventario
    {
        private readonly ProductoOrdenInventarioRepository _productoOrdenInventarioRepository
            = new ProductoOrdenInventarioRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<ProductoOrdenInventario, UniversalExtend>> source)
        {
            return await _productoOrdenInventarioRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<ProductoOrdenInventario, bool>> predicate, Expression<Func<ProductoOrdenInventario, UniversalExtend>> source)
        {
            return await _productoOrdenInventarioRepository.SelectList(predicate, source);
        }

        public async Task<ProductoOrdenInventario> Single(Expression<Func<ProductoOrdenInventario, bool>> predicate)
        {
            return await _productoOrdenInventarioRepository.Single(predicate);
        }

        public async Task<ProductoOrdenInventario> Single(Expression<Func<ProductoOrdenInventario, bool>> predicate,
            List<Expression<Func<ProductoOrdenInventario, object>>> includes)
        {
            return await _productoOrdenInventarioRepository.Single(predicate, includes);
        }

        public async Task Create(ProductoOrdenInventario entity)
        {
            if (entity.ProductoOrdenInventarioId != default)
                await _productoOrdenInventarioRepository.Update(entity);
            else
            {
                bool exist = await _productoOrdenInventarioRepository.Exist(x => x.ProductoOrdenInventarioId == entity.ProductoOrdenInventarioId);
                if (exist)
                    throw new CustomException("El número de documento que intenta registrar ya existe.");
                await _productoOrdenInventarioRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<ProductoOrdenInventario, bool>> predicate)
        {
            await _productoOrdenInventarioRepository.Delete(predicate);
        }

        public async Task<IEnumerable<ProductoOrdenInventarioExtend>> ListaProductoOrdenInventario(int id)
        {
            return await _productoOrdenInventarioRepository.ListaProductoOrdenInventario(id);
        }

        /// <summary>
        /// Método para buscar Producto Ordenes de Inventario
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductoOrdenInventarioExtend>> SelectProductoOrdenesInventario
            (CriteriaProductoOrdenInventario filter)
        {
            return await _productoOrdenInventarioRepository.SelectProductoOrdenesInventario(filter);
        }
    }
}
