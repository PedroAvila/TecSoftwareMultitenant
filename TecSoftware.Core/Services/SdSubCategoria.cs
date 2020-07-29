using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdSubCategoria : ISdSubCategoria
    {
        private readonly SubCategoriaRepository _subCategoriaRepository = new SubCategoriaRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<SubCategoria, UniversalExtend>> source)
        {
            return await _subCategoriaRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<SubCategoria, bool>> predicate,
            Expression<Func<SubCategoria, UniversalExtend>> source)
        {
            return await _subCategoriaRepository.SelectList(predicate, source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaSubCategoria(Expression<Func<SubCategoria, bool>> predicate,
            Expression<Func<SubCategoria, UniversalExtend>> source)
        {
            var listItem = Task.Run(() => SelectList(predicate, source)).Result;
            listItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<Seleccione>>" });
            return (Task<IEnumerable<UniversalExtend>>)listItem;
        }

        public async Task<SubCategoria> Single(Expression<Func<SubCategoria, bool>> predicate)
        {
            return await _subCategoriaRepository.Single(predicate);
        }

        public async Task Create(SubCategoria entity)
        {
            if (entity.SubCategoriaId != default(int))
                await _subCategoriaRepository.Update(entity);
            else
            {
                var exist = await _subCategoriaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La Sub Categoría que intenta registrar ya existe.");
                await _subCategoriaRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<SubCategoria, bool>> predicate)
        {
            await _subCategoriaRepository.Delete(predicate);
        }
    }
}
