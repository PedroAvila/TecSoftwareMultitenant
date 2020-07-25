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
    public class SdCategoria
    {
        private readonly CategoriaRepository _categoriaRepository = new CategoriaRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Categoria, UniversalExtend>> source)
        {
            return await _categoriaRepository.SelectList(source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaCategoria(Expression<Func<Categoria, UniversalExtend>> source)
        {
            var listItem = Task.Run(() => SelectList(source)).Result;
            listItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<Seleccione>>" });
            return (Task<IEnumerable<UniversalExtend>>)listItem;
        }

        public async Task Create(Categoria entity)
        {
            if (entity.CategoriaId != default(int))
                await _categoriaRepository.Update(entity);
            else
            {
                var exist = await _categoriaRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La categoría que intenta registrar ya existe.");
                await _categoriaRepository.Create(entity);
            }
        }

        public async Task<Categoria> Single(Expression<Func<Categoria, bool>> predicate)
        {
            return await _categoriaRepository.Single(predicate);
        }

        public async Task Delete(Expression<Func<Categoria, bool>> predicate)
        {
            await _categoriaRepository.Delete(predicate);
        }
    }
}
