using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdOperacion : ISdOperacion
    {
        private readonly OperacionRepository _operacionRepository = new OperacionRepository();


        public async Task Create(Operacion entity)
        {
            if (entity.OperacionId != default)
                await _operacionRepository.Update(entity);
            else
            {
                var exist = await _operacionRepository.Exist(x => x.PuntoEmisionId == entity.PuntoEmisionId
                && x.OperacionStatus == OperacionCaja.Abrir);
                if (exist)
                    throw new CustomException("Ya exite una operación abierta con ese punto de emisión");
                await _operacionRepository.Create(entity);
            }
        }

        public async Task<bool> Exist(Expression<Func<Operacion, bool>> predicate)
        {
            return await _operacionRepository.Exist(predicate);
        }

        public async Task<Operacion> Single(Expression<Func<Operacion, bool>> predicate)
        {
            return await _operacionRepository.Single(predicate);
        }
    }
}
