using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdPresentacion
    {
        private readonly PresentacionRepository _presentacionRepository = new PresentacionRepository();
        private readonly PresentacionValidator _presentacionValidator = new PresentacionValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Presentacion, UniversalExtend>> source)
        {
            return _presentacionRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> ListaPresentacion(Expression<Func<Presentacion, UniversalExtend>> source)
        {
            var listaItem = SelectList(source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Presentacion, bool>> predicate,
            Expression<Func<Presentacion, UniversalExtend>> source)
        {
            return _presentacionRepository.SelectList(predicate, source);
        }

        public void Create(Presentacion entity)
        {
            var result = _presentacionValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.PresentacionId != default(int))
                _presentacionRepository.Update(entity);
            else
            {
                var exist = _presentacionRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La presentación que intenta registrar ya existe.");
                _presentacionRepository.Create(entity);
            }
        }

        public Presentacion Single(Expression<Func<Presentacion, bool>> predicate)
        {
            return _presentacionRepository.Single(predicate);
        }
    }
}
