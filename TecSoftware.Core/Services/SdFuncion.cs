using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdFuncion
    {
        private readonly FuncionRepository _funcionRepository = new FuncionRepository();
        private readonly FuncionValidator _funcionValidator = new FuncionValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Funcion, UniversalExtend>> source)
        {
            return _funcionRepository.SelectList(source);
        }

        public void Create(Funcion entity)
        {
            var result = _funcionValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.FuncionId != default)
                _funcionRepository.Update(entity);
            else
            {
                var exist = _funcionRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La Función que intenta registrar ya existe.");
                _funcionRepository.Create(entity);
            }
        }

        public Funcion Single(Expression<Func<Funcion, bool>> predicate)
        {
            return _funcionRepository.Single(predicate);
        }

        public void Delete(Expression<Func<Funcion, bool>> predicate)
        {
            _funcionRepository.Delete(predicate);
        }
    }
}
