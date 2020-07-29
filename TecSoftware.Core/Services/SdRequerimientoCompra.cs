using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdRequerimientoCompra : ISdRequerimientoCompra
    {
        private readonly RequerimientoCompraRepository _requerimientoCompraRepository =
            new RequerimientoCompraRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectRequerimientoCompra(CriteriaDocumento filter)
        {
            return await _requerimientoCompraRepository.SelectRequerimientoCompra(filter);
        }

        public async Task<RequerimientoCompra> Single(Expression<Func<RequerimientoCompra, bool>> predicate)
        {
            return await _requerimientoCompraRepository.Single(predicate);
        }

        public async Task Create(RequerimientoCompra entity)
        {
            if (entity.RequerimientoCompraId != default)
                await _requerimientoCompraRepository.Update(entity);
            else
            {
                bool exist = await _requerimientoCompraRepository
                    .Exist(x => x.RequerimientoCompraId == entity.RequerimientoCompraId);
                if (exist)
                    throw new CustomException("El Requerimiento de Compra que intenta registrar ya existe.");
                entity.NumeroRequerimiento = await _requerimientoCompraRepository.GenerarCodigo();
                await _requerimientoCompraRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<RequerimientoCompra, bool>> predicate)
        {
            await _requerimientoCompraRepository.Delete(predicate);
        }
    }
}
