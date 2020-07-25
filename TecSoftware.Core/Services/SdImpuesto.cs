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
    public class SdImpuesto
    {
        private readonly ImpuestoRepository _impuestoRepository = new ImpuestoRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Impuesto, UniversalExtend>> source)
        {
            return await _impuestoRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<Impuesto, bool>> predicate, Expression<Func<Impuesto, UniversalExtend>> source)
        {
            return await _impuestoRepository.SelectList(predicate, source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaImpuestos(Expression<Func<Impuesto, bool>> predicate,
            Expression<Func<Impuesto, UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(predicate, source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<Impuesto> Single(Expression<Func<Impuesto, bool>> predicate)
        {
            return await _impuestoRepository.Single(predicate);
        }

        public async Task Create(Impuesto entity)
        {
            if (entity.ImpuestoId != default(int))
                await _impuestoRepository.Update(entity);
            else
            {
                bool exist = await _impuestoRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El impuesto que intenta registrar ya existe.");
                await _impuestoRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Impuesto, bool>> predicate)
        {
            await _impuestoRepository.Delete(predicate);
        }
    }
}
