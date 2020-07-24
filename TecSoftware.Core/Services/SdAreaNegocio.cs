using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdAreaNegocio
    {
        private readonly AreaNegocioRepository _areaNegocioRepository = new AreaNegocioRepository();
        private readonly AreaNegocioValidator _areaNegocioValidator = new AreaNegocioValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<AreaNegocio, UniversalExtend>> source)
        {
            return _areaNegocioRepository.SelectList(source).ToList();
        }

        public IEnumerable<UniversalExtend> ListaAreaNegocio(Expression<Func<AreaNegocio, UniversalExtend>> source)
        {
            var listaItem = SelectList(source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public AreaNegocio Single(Expression<Func<AreaNegocio, bool>> predicate)
        {
            return _areaNegocioRepository.Single(predicate);
        }

        public void Create(AreaNegocio entity)
        {
            var result = _areaNegocioValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.AreaNegocioId != default)
                _areaNegocioRepository.Update(entity);
            else
            {
                bool exist = _areaNegocioRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Área de negocio que intenta registrar ya existe.");
                _areaNegocioRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<AreaNegocio, bool>> predicate)
        {
            _areaNegocioRepository.Delete(predicate);
        }
    }
}
