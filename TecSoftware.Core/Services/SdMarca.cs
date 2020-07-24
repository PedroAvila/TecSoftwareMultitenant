using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdMarca
    {
        private readonly MarcaRepository _marcaRepository = new MarcaRepository();
        private readonly MarcaValidator _marcaValidator = new MarcaValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Marca, UniversalExtend>> source)
        {
            return _marcaRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Marca, bool>> predicate,
            Expression<Func<Marca, UniversalExtend>> source)
        {
            return _marcaRepository.SelectList(predicate, source);
        }

        public void Create(Marca entity)
        {
            var result = _marcaValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.MarcaId != default(int))
                _marcaRepository.Update(entity);
            else
            {
                var exist = _marcaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La marca que intenta registrar ya existe.");
                _marcaRepository.Create(entity);
            }
        }
    }
}
