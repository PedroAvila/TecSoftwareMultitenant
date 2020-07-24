using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdMoneda
    {
        private readonly MonedaRepository _monedaRepository = new MonedaRepository();
        private readonly MonedaValidator _monedaValidator = new MonedaValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Moneda, UniversalExtend>> source)
        {
            return _monedaRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> ListaMonedas(Expression<Func<Moneda, UniversalExtend>> source)
        {
            var listItem = SelectList(source).ToList();
            listItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<Seleccione>>" });
            return listItem;
        }

        public Moneda Single(Expression<Func<Moneda, bool>> predicate)
        {
            return _monedaRepository.Single(predicate);
        }

        public void Create(Moneda entity)
        {
            var result = _monedaValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.MonedaId != default(int))
                _monedaRepository.Update(entity);
            else
            {
                bool exist = _monedaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La Moneda que intenta registrar ya existe.");
                _monedaRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Moneda, bool>> predicate)
        {
            _monedaRepository.Delete(predicate);
        }
    }
}
