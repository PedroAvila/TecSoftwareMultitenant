using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdCategoria
    {
        private readonly CategoriaRepository _categoriaRepository = new CategoriaRepository();
        private readonly CategoriaValidator _categoriaValidator = new CategoriaValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Categoria, UniversalExtend>> source)
        {
            return _categoriaRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> ListaCategoria(Expression<Func<Categoria, UniversalExtend>> source)
        {
            var listItem = SelectList(source).ToList();
            listItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<Seleccione>>" });
            return listItem;
        }

        public void Create(Categoria entity)
        {
            var result = _categoriaValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.CategoriaId != default(int))
                _categoriaRepository.Update(entity);
            else
            {
                var exist = _categoriaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La categoría que intenta registrar ya existe.");
                _categoriaRepository.Create(entity);
            }
        }

        public Categoria Single(Expression<Func<Categoria, bool>> predicate)
        {
            return _categoriaRepository.Single(predicate);
        }

        public void Delete(Expression<Func<Categoria, bool>> predicate)
        {
            _categoriaRepository.Delete(predicate);
        }
    }
}
