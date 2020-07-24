using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdMedida
    {
        private readonly MedidaRepository _medidaRepository = new MedidaRepository();
        private readonly MedidaValidator _medidaValidator = new MedidaValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Medida, UniversalExtend>> source)
        {
            return _medidaRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> ListaMedida(Expression<Func<Medida, UniversalExtend>> source)
        {
            var listItem = SelectList(source).ToList();
            listItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<Seleccione>>" });
            return listItem;
        }

        public void Create(Medida entity)
        {
            var result = _medidaValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.MedidaId != default)
                _medidaRepository.Update(entity);
            else
            {
                var exist = _medidaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La medida que intenta registrar ya existe.");
                _medidaRepository.Create(entity);
            }
        }

        public Medida Single(Expression<Func<Medida, bool>> predicate)
        {
            return _medidaRepository.Single(predicate);
        }

        public void Delete(Expression<Func<Medida, bool>> predicate)
        {
            _medidaRepository.Delete(predicate);
        }
    }
}
