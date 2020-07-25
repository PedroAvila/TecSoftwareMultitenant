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
    public class SdEstablecimiento
    {
        private readonly EstablecimientoRepository _establecimientoRepository = new EstablecimientoRepository();


        public IEnumerable<Establecimiento> GetAll()
        {
            return _establecimientoRepository.GetAll();
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Establecimiento, UniversalExtend>> source)
        {
            return await _establecimientoRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Establecimiento, bool>> predicate,
            Expression<Func<Establecimiento, UniversalExtend>> source)
        {
            return await _establecimientoRepository.SelectList(predicate, source);

        }

        public Task<IEnumerable<UniversalExtend>> ListaEstablecimientos(Expression<Func<Establecimiento,
            UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public Task<IEnumerable<UniversalExtend>> ListaEstablecimientos(Expression<Func<Establecimiento, bool>> predicate,
            Expression<Func<Establecimiento, UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(predicate, source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public Task<IEnumerable<UniversalExtend>> ListaTodoEstablecimientos(Expression<Func<Establecimiento,
            UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Todos>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<Establecimiento> Single(Expression<Func<Establecimiento, bool>> predicate)
        {
            return await _establecimientoRepository.Single(predicate);
        }

        public async Task Create(Establecimiento entity)
        {
            if (entity.EstablecimientoId != default(int))
                await _establecimientoRepository.Update(entity);
            else
            {
                bool exist = await _establecimientoRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Establecimiento que intenta registrar ya existe.");
                await _establecimientoRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Establecimiento, bool>> predicate)
        {
            await _establecimientoRepository.Delete(predicate);
        }
    }
}
