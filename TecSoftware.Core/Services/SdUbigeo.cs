using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdUbigeo
    {
        private readonly UbigeoRepository _ubigeoRepository = new UbigeoRepository();
        private readonly UbigeoValidator _ubigeoValidator = new UbigeoValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Ubigeo, UniversalExtend>> source)
        {
            return _ubigeoRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> ListaUbigeo(Expression<Func<Ubigeo, UniversalExtend>> source)
        {
            var listItem = SelectList(source).ToList();
            listItem.Insert(0, new UniversalExtend() { Codigo = Convert.ToString(-1), Descripcion = "<<Seleccione>>" });
            return listItem;
        }

        public Ubigeo Single(Expression<Func<Ubigeo, bool>> predicate)
        {
            return _ubigeoRepository.Single(predicate);
        }

        public void Create(Ubigeo entity)
        {
            var result = _ubigeoValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.UbigeoId != default(int))
                _ubigeoRepository.Update(entity);
            else
            {
                //bool exist = _ubigeoRepository.Exist(x => x. == entity.Numero);
                //if (exist)
                //    throw new CustomException("El número de documento que intenta registrar ya existe.");
                _ubigeoRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Ubigeo, bool>> predicate)
        {
            _ubigeoRepository.Delete(predicate);
        }
    }
}
