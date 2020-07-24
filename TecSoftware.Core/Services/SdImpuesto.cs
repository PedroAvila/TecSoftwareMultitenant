using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdImpuesto
    {
        private readonly ImpuestoRepository _impuestoRepository = new ImpuestoRepository();
        private readonly ImpuestoValidator _impuestoValidator = new ImpuestoValidator();
        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Impuesto, UniversalExtend>> source)
        {
            return _impuestoRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList
            (Expression<Func<Impuesto, bool>> predicate, Expression<Func<Impuesto, UniversalExtend>> source)
        {
            return _impuestoRepository.SelectList(predicate, source);
        }

        public IEnumerable<UniversalExtend> ListaImpuestos(Expression<Func<Impuesto, bool>> predicate,
            Expression<Func<Impuesto, UniversalExtend>> source)
        {
            var listaItem = SelectList(predicate, source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public Impuesto Single(Expression<Func<Impuesto, bool>> predicate)
        {
            return _impuestoRepository.Single(predicate);
        }

        public void Create(Impuesto entity)
        {
            var result = _impuestoValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.ImpuestoId != default(int))
                _impuestoRepository.Update(entity);
            else
            {
                bool exist = _impuestoRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El impuesto que intenta registrar ya existe.");
                _impuestoRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Impuesto, bool>> predicate)
        {
            _impuestoRepository.Delete(predicate);
        }
    }
}
