using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdFormaPago
    {
        private readonly FormaPagoRepository _formaPagoRepository = new FormaPagoRepository();
        private readonly FormaPagoValidator _formaPagoValidator = new FormaPagoValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<FormaPago, UniversalExtend>> source)
        {
            return _formaPagoRepository.SelectList(source);
        }

        public FormaPago Single(Expression<Func<FormaPago, bool>> predicate)
        {
            return _formaPagoRepository.Single(predicate);
        }

        public void Create(FormaPago entity)
        {
            var result = _formaPagoValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.FormaPagoId != default(int))
                _formaPagoRepository.Update(entity);
            else
            {
                bool exist = _formaPagoRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La forma de pago que intenta registrar ya existe.");
                _formaPagoRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<FormaPago, bool>> predicate)
        {
            _formaPagoRepository.Delete(predicate);
        }
    }
}
