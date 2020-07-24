using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdRequerimientoCompra
    {
        private readonly RequerimientoCompraRepository _requerimientoCompraRepository = new RequerimientoCompraRepository();
        private readonly RequerimientoCompraValidator _requerimientoCompraValidator = new RequerimientoCompraValidator();

        public IEnumerable<UniversalExtend> SelectRequerimientoCompra(CriteriaDocumento filter)
        {
            return _requerimientoCompraRepository.SelectRequerimientoCompra(filter);
        }

        public RequerimientoCompra Single(Expression<Func<RequerimientoCompra, bool>> predicate)
        {
            return _requerimientoCompraRepository.Single(predicate);
        }

        public void Create(RequerimientoCompra entity)
        {
            var result = _requerimientoCompraValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.RequerimientoCompraId != default)
                _requerimientoCompraRepository.Update(entity);
            else
            {
                bool exist = _requerimientoCompraRepository.Exist(x => x.RequerimientoCompraId == entity.RequerimientoCompraId);
                if (exist)
                    throw new CustomException("El Requerimiento de Compra que intenta registrar ya existe.");
                entity.NumeroRequerimiento = _requerimientoCompraRepository.GenerarCodigo();
                _requerimientoCompraRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<RequerimientoCompra, bool>> predicate)
        {
            _requerimientoCompraRepository.Delete(predicate);
        }
    }
}
