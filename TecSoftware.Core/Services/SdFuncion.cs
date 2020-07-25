using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdFuncion
    {
        private readonly FuncionRepository _funcionRepository = new FuncionRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Funcion, UniversalExtend>> source)
        {
            return await _funcionRepository.SelectList(source);
        }

        public async Task Create(Funcion entity)
        {
            if (entity.FuncionId != default)
                await _funcionRepository.Update(entity);
            else
            {
                var exist = await _funcionRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La Función que intenta registrar ya existe.");
                await _funcionRepository.Create(entity);
            }
        }

        public async Task<Funcion> Single(Expression<Func<Funcion, bool>> predicate)
        {
            return await _funcionRepository.Single(predicate);
        }

        public async Task Delete(Expression<Func<Funcion, bool>> predicate)
        {
            await _funcionRepository.Delete(predicate);
        }
    }
}
