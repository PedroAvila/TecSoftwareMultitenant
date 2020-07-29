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
    public class SdAlmacen : ISdAlmacen
    {
        private readonly AlmacenRepository _almacenRepository = new AlmacenRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Almacen, UniversalExtend>> source)
        {
            return await _almacenRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<Almacen, bool>> predicate, Expression<Func<Almacen, UniversalExtend>> source)
        {
            return await _almacenRepository.SelectList(predicate, source);
        }

        public Task<IEnumerable<UniversalExtend>> ListarBodega
            (Expression<Func<Almacen, bool>> predicate, Expression<Func<Almacen, UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(predicate, source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<Almacen> Single(Expression<Func<Almacen, bool>> predicate)
        {
            return await _almacenRepository.Single(predicate);
        }

        public async Task Create(Almacen entity)
        {
            if (entity.AlmacenId != default)
                await _almacenRepository.Update(entity);
            else
            {
                bool exist = await _almacenRepository.Exist(x => x.EstablecimientoId == entity.EstablecimientoId
                 && x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El almacén que intenta registrar ya existe.");
                await _almacenRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Almacen, bool>> predicate)
        {
            await _almacenRepository.Delete(predicate);
        }
    }
}
