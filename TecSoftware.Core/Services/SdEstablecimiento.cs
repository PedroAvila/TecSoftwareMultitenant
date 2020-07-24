using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdEstablecimiento
    {
        private readonly EstablecimientoRepository _establecimientoRepository = new EstablecimientoRepository();
        private readonly EstablecimientoValidator _establecimientoValidator = new EstablecimientoValidator();

        public IEnumerable<Establecimiento> GetAll()
        {
            return _establecimientoRepository.GetAll();
        }

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Establecimiento, UniversalExtend>> source)
        {
            return _establecimientoRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Establecimiento, bool>> predicate,
            Expression<Func<Establecimiento, UniversalExtend>> source)
        {
            return _establecimientoRepository.SelectList(predicate, source);

        }

        public IEnumerable<UniversalExtend> ListaEstablecimientos(Expression<Func<Establecimiento,
            UniversalExtend>> source)
        {
            var listaItem = SelectList(source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public IEnumerable<UniversalExtend> ListaEstablecimientos(Expression<Func<Establecimiento, bool>> predicate,
            Expression<Func<Establecimiento, UniversalExtend>> source)
        {
            var listaItem = SelectList(predicate, source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public IEnumerable<UniversalExtend> ListaTodoEstablecimientos(Expression<Func<Establecimiento,
            UniversalExtend>> source)
        {
            var listaItem = SelectList(source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Todos>>>" });
            return listaItem;
        }

        public Establecimiento Single(Expression<Func<Establecimiento, bool>> predicate)
        {
            return _establecimientoRepository.Single(predicate);
        }

        public void Create(Establecimiento entity)
        {
            var result = _establecimientoValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.EstablecimientoId != default(int))
                _establecimientoRepository.Update(entity);
            else
            {
                bool exist = _establecimientoRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Establecimiento que intenta registrar ya existe.");
                _establecimientoRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Establecimiento, bool>> predicate)
        {
            _establecimientoRepository.Delete(predicate);
        }
    }
}
