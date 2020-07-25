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
    public class SdComprobante
    {
        private readonly ComprobanteRepository _comprobanteRepository = new ComprobanteRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Comprobante, UniversalExtend>> source)
        {
            return await _comprobanteRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<Comprobante, bool>> predicate, Expression<Func<Comprobante, UniversalExtend>> source)
        {
            return await _comprobanteRepository.SelectList(predicate, source);
        }

        /// <summary>
        /// Sin Guía de Remisión
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UniversalExtend>> ComprobantePagos()
        {
            return await _comprobanteRepository.ComprobantePagos();
        }

        /// <summary>
        /// Lista de Comprobantes excepto Guía de Remisión.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<UniversalExtend>> ListaComprobantes()
        {
            var listaItem = Task.Run(() => ComprobantePagos()).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        //public IEnumerable<Comprobante> Filter
        //    (Expression<Func<Comprobante, bool>> predicate,
        //    List<Expression<Func<Comprobante, object>>> includes)
        //{
        //    return _comprobanteRepository.Filter(predicate, includes);
        //}

        public Task<IEnumerable<UniversalExtend>> ListaComprobantes(Expression<Func<Comprobante,
            UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<Comprobante> Single(Expression<Func<Comprobante, bool>> predicate)
        {
            return await _comprobanteRepository.Single(predicate);
        }

        public async Task<Comprobante> Single(Expression<Func<Comprobante, bool>> predicate,
            List<Expression<Func<Comprobante, object>>> includes)
        {
            return await _comprobanteRepository.Single(predicate, includes);
        }

        public async Task Create(Comprobante entity)
        {
            if (entity.ComprobanteId != default(int))
                await _comprobanteRepository.Update(entity);
            else
            {
                bool exist = await _comprobanteRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Comprobante que intenta registrar ya existe.");
                await _comprobanteRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Comprobante, bool>> predicate)
        {
            await _comprobanteRepository.Delete(predicate);
        }

        public async Task AsignarIdentificaciones(Comprobante comprobante, List<TipoIdentificacion> identificaciones)
        {
            await _comprobanteRepository.AsignarIdentificaciones(comprobante, identificaciones);
        }

        public async Task RemoveIdentificaciones(Comprobante comprobante, List<TipoIdentificacion> identificaciones)
        {
            await _comprobanteRepository.RemoveIdentificaciones(comprobante, identificaciones);
        }
    }
}
