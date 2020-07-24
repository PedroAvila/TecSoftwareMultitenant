using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdColor
    {
        private readonly ColorRepository _colorRepository = new ColorRepository();
        private readonly ColorValidator _colorValidator = new ColorValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Colour, UniversalExtend>> source)
        {
            return _colorRepository.SelectList(source);
        }

        public List<Colour> MostrarColors()
        {
            return _colorRepository.DetalleItemTemp;
        }

        public void Agregar(Colour entity)
        {
            _colorRepository.Agregar(entity);
        }

        public void CleanColor()
        {
            _colorRepository.CleanColor();
        }

        public Colour Single(Expression<Func<Colour, bool>> predicate)
        {
            return _colorRepository.Single(predicate);
        }

        public void Create(Colour entity)
        {
            var result = _colorValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.ColorId != default)
                _colorRepository.Update(entity);
            else
            {
                var exist = _colorRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El color que intenta registrar ya existe.");
                _colorRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Colour, bool>> predicate)
        {
            _colorRepository.Delete(predicate);
        }
    }
}
