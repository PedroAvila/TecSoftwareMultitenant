using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdTalla
    {
        private readonly TallaRepository _tallaRepository = new TallaRepository();
        private readonly TallaValidator _tallaValidator = new TallaValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Talla, UniversalExtend>> source)
        {
            return _tallaRepository.SelectList(source);
        }

        public List<Talla> MostrarTallas()
        {
            return _tallaRepository.DetalleItemTemp;
        }

        public void Agregar(Talla entity)
        {
            _tallaRepository.Agregar(entity);
        }

        public void CleanTalla()
        {
            _tallaRepository.CleanTalla();
        }

        public Talla Single(Expression<Func<Talla, bool>> predicate)
        {
            return _tallaRepository.Single(predicate);
        }

        public void Create(Talla entity)
        {
            var result = _tallaValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.TallaId != default(int))
                _tallaRepository.Update(entity);
            else
            {
                var exist = _tallaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La talla que intenta registrar ya existe.");
                _tallaRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Talla, bool>> predicate)
        {
            _tallaRepository.Delete(predicate);
        }
    }
}
