using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdOperacionMovimiento
    {
        public readonly OperacionMovimientoRepository _operacionMovimientoRepository = new OperacionMovimientoRepository();

        public void Create(OperacionMovimiento entity)
        {
            //var result = _clienteValidator.Validate(entity);
            //if (!result.IsValid)
            //    throw new CustomException(Validator.GetErrorMessages(result.Errors));
            //if (entity.ClienteId != default(int))
            //    _clienteRepository.Update(entity);
            //else
            //{
            //    bool exist = _clienteRepository.Exist(x => x.Numero == entity.Numero);
            //    if (exist)
            //        throw new CustomException("El número de documento que intenta registrar ya existe.");
            //    _clienteRepository.Create(entity);
            //}
            _operacionMovimientoRepository.Registrar(entity);
        }
    }
}
