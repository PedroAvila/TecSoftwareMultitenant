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
    public class SdTipoIdentificacion
    {
        private readonly TipoIdentificacionRepository _tipoIdentificacionRepository =
            new TipoIdentificacionRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<TipoIdentificacion, UniversalExtend>> source)
        {
            return await _tipoIdentificacionRepository.SelectList(source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaIdentificacionXCodigo()
        {
            var listaItem = Task.Run(() => ListaXCodigo()).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<List<ICollection<TipoIdentificacion>>> IdentificacionXComprobante(int id)
        {
            return await _tipoIdentificacionRepository.IdentificacionXComprobante(id);
        }

        public async Task<IEnumerable<TipoIdentificacionExtend>> ListaVinculacionDatos
            (Expression<Func<TipoIdentificacion, TipoIdentificacionExtend>> source)
        {
            return await _tipoIdentificacionRepository.ListaVinculacionDatos(source);
        }

        public async Task<IEnumerable<UniversalExtend>> ListaXCodigo()
        {
            return await _tipoIdentificacionRepository.ListaIdentificacionXCodigo();
        }

        public async Task<TipoIdentificacion> Single(Expression<Func<TipoIdentificacion, bool>> predicate)
        {
            return await _tipoIdentificacionRepository.Single(predicate);
        }

        public async Task Create(TipoIdentificacion entity)
        {
            if (entity.TipoIdentificacionId != default(int))
                await _tipoIdentificacionRepository.Update(entity);
            else
            {
                bool exist = await _tipoIdentificacionRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Tipo de Identificación que intenta registrar ya existe.");
                await _tipoIdentificacionRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<TipoIdentificacion, bool>> predicate)
        {
            await _tipoIdentificacionRepository.Delete(predicate);
        }


    }
}
