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
    public class SdPresentacion
    {
        private readonly PresentacionRepository _presentacionRepository = new PresentacionRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Presentacion, UniversalExtend>> source)
        {
            return await _presentacionRepository.SelectList(source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaPresentacion(Expression<Func<Presentacion, UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Presentacion, bool>> predicate,
            Expression<Func<Presentacion, UniversalExtend>> source)
        {
            return await _presentacionRepository.SelectList(predicate, source);
        }

        public async Task Create(Presentacion entity)
        {
            if (entity.PresentacionId != default(int))
                await _presentacionRepository.Update(entity);
            else
            {
                var exist = await _presentacionRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La presentación que intenta registrar ya existe.");
                await _presentacionRepository.Create(entity);
            }
        }

        public async Task<Presentacion> Single(Expression<Func<Presentacion, bool>> predicate)
        {
            return await _presentacionRepository.Single(predicate);
        }
    }
}
