using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdListaPrecio
    {
        private readonly ListaPrecioRepository _listaPrecioRepository = new ListaPrecioRepository();
        private readonly ListaPrecioValidator _listaPrecioValidator = new ListaPrecioValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<ListaPrecio, UniversalExtend>> source)
        {
            return _listaPrecioRepository.SelectList(source);
        }


        public ListaPrecio Single(Expression<Func<ListaPrecio, bool>> predicate)
        {
            return _listaPrecioRepository.Single(predicate);
        }

        public void Create(ListaPrecio entity)
        {
            var result = _listaPrecioValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.ListaPrecioId != default(int))
                _listaPrecioRepository.Update(entity);
            else
            {
                bool exist = _listaPrecioRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La lista que intenta registrar ya existe.");
                _listaPrecioRepository.Create(entity);
            }
        }
    }
}
