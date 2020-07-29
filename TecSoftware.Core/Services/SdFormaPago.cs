using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdFormaPago : ISdFormaPago
    {
        private readonly FormaPagoRepository _formaPagoRepository = new FormaPagoRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<FormaPago, UniversalExtend>> source)
        {
            return await _formaPagoRepository.SelectList(source);
        }

        public async Task<FormaPago> Single(Expression<Func<FormaPago, bool>> predicate)
        {
            return await _formaPagoRepository.Single(predicate);
        }

        public async Task Create(FormaPago entity)
        {
            if (entity.FormaPagoId != default(int))
                await _formaPagoRepository.Update(entity);
            else
            {
                bool exist = await _formaPagoRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La forma de pago que intenta registrar ya existe.");
                await _formaPagoRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<FormaPago, bool>> predicate)
        {
            await _formaPagoRepository.Delete(predicate);
        }
    }
}
