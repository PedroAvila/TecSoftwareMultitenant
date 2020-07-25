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
    public class SdConceptoInventario
    {
        private readonly ConceptoInventarioRepository _conceptoInventarioRepository =
            new ConceptoInventarioRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<ConceptoInventario, UniversalExtend>> source)
        {
            return await _conceptoInventarioRepository.SelectList(source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaConceptoInventario(Expression<Func<ConceptoInventario, UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<ConceptoInventario> Single(Expression<Func<ConceptoInventario, bool>> predicate)
        {
            return await _conceptoInventarioRepository.Single(predicate);
        }

        public async Task Create(ConceptoInventario entity)
        {
            if (entity.ConceptoInventarioId != default)
                await _conceptoInventarioRepository.Update(entity);
            else
            {
                bool exist = await _conceptoInventarioRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Concepto de Inventario que intenta registrar ya existe.");
                await _conceptoInventarioRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<ConceptoInventario, bool>> predicate)
        {
            await _conceptoInventarioRepository.Delete(predicate);
        }
    }
}
