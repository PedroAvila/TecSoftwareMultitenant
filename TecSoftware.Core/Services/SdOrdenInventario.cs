using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdOrdenInventario : ISdOrdenInventario
    {
        public readonly OrdenInventarioRepository _ordenInventarioRepository = new OrdenInventarioRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<OrdenInventario, UniversalExtend>> source)
        {
            return await _ordenInventarioRepository.SelectList(source);
        }

        public async Task Create(OrdenInventario entity)
        {
            if (entity.OrdenInventarioId != default)
                await _ordenInventarioRepository.Update(entity);
            else
            {
                var exist = await _ordenInventarioRepository.Exist(x => x.NumeroOrden == entity.NumeroOrden);
                if (exist)
                    throw new CustomException("La Orden de Inventario que intenta registrar ya existe.");
                entity.NumeroOrden = await _ordenInventarioRepository.GenerarCodigo();
                await _ordenInventarioRepository.Create(entity);
            }
        }

        public async Task<OrdenInventario> Single(Expression<Func<OrdenInventario, bool>> predicate)
        {
            return await _ordenInventarioRepository.Single(predicate);
        }

        public async Task<OrdenInventario> Single(Expression<Func<OrdenInventario, bool>> predicate,
            List<Expression<Func<OrdenInventario, object>>> includes)
        {
            return await _ordenInventarioRepository.Single(predicate, includes);
        }

        public async Task Delete(Expression<Func<OrdenInventario, bool>> predicate)
        {
            await _ordenInventarioRepository.Delete(predicate);
        }

        public async Task<IEnumerable<OrdenInventarioExtend>> SelectOrdenesInventario(CriteriaOrdenInventario filter)
        {
            return await _ordenInventarioRepository.SelectOrdenesInventario(filter);
        }
    }
}
