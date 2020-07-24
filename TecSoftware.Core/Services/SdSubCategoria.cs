using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdSubCategoria
    {
        private readonly SubCategoriaRepository _subCategoriaRepository = new SubCategoriaRepository();
        private readonly SubCategoriaValidator _subCategoriaValidator = new SubCategoriaValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<SubCategoria, UniversalExtend>> source)
        {
            return _subCategoriaRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<SubCategoria, bool>> predicate,
            Expression<Func<SubCategoria, UniversalExtend>> source)
        {
            return _subCategoriaRepository.SelectList(predicate, source);
        }

        public IEnumerable<UniversalExtend> ListaSubCategoria(Expression<Func<SubCategoria, bool>> predicate,
            Expression<Func<SubCategoria, UniversalExtend>> source)
        {
            var listItem = SelectList(predicate, source).ToList();
            listItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<Seleccione>>" });
            return listItem;
        }

        public SubCategoria Single(Expression<Func<SubCategoria, bool>> predicate)
        {
            return _subCategoriaRepository.Single(predicate);
        }

        public void Create(SubCategoria entity)
        {
            var result = _subCategoriaValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.SubCategoriaId != default(int))
                _subCategoriaRepository.Update(entity);
            else
            {
                var exist = _subCategoriaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La Sub Categoría que intenta registrar ya existe.");
                _subCategoriaRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<SubCategoria, bool>> predicate)
        {
            _subCategoriaRepository.Delete(predicate);
        }
    }
}
