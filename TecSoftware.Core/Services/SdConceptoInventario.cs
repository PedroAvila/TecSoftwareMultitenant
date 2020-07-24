using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdConceptoInventario
    {
        private readonly ConceptoInventarioRepository _conceptoInventarioRepository =
            new ConceptoInventarioRepository();
        private readonly ConceptoInventarioValidator _conceptoInventarioValidator =
            new ConceptoInventarioValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<ConceptoInventario, UniversalExtend>> source)
        {
            return _conceptoInventarioRepository.SelectList(source).ToList();
        }

        public IEnumerable<UniversalExtend> ListaConceptoInventario(Expression<Func<ConceptoInventario, UniversalExtend>> source)
        {
            var listaItem = SelectList(source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public ConceptoInventario Single(Expression<Func<ConceptoInventario, bool>> predicate)
        {
            return _conceptoInventarioRepository.Single(predicate);
        }

        public void Create(ConceptoInventario entity)
        {
            var result = _conceptoInventarioValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.ConceptoInventarioId != default)
                _conceptoInventarioRepository.Update(entity);
            else
            {
                bool exist = _conceptoInventarioRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Concepto de Inventario que intenta registrar ya existe.");
                _conceptoInventarioRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<ConceptoInventario, bool>> predicate)
        {
            _conceptoInventarioRepository.Delete(predicate);
        }
    }
}
