using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdOperacion
    {
        private readonly OperacionRepository _operacionRepository = new OperacionRepository();
        private readonly OperacionValidator _operacionValidator = new OperacionValidator();

        public void Create(Operacion entity)
        {
            var result = _operacionValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.OperacionId != default)
                _operacionRepository.Update(entity);
            else
            {
                var exist = _operacionRepository.Exist(x => x.PuntoEmisionId == entity.PuntoEmisionId
                && x.OperacionStatus == OperacionType.Abrir);
                if (exist)
                    throw new CustomException("Ya exite una operación abierta con ese punto de emisión");
                _operacionRepository.Create(entity);
            }
        }

        public bool Exist(Expression<Func<Operacion, bool>> predicate)
        {
            return _operacionRepository.Exist(predicate);
        }

        public async Task<Operacion> Single(Expression<Func<Operacion, bool>> predicate)
        {
            return await _operacionRepository.Single(predicate);
        }
    }
}
