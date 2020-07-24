using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdComprobante
    {
        private readonly ComprobanteRepository _comprobanteRepository = new ComprobanteRepository();
        private readonly ComprobanteValidator _comprobanteValidator = new ComprobanteValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Comprobante, UniversalExtend>> source)
        {
            return _comprobanteRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList
            (Expression<Func<Comprobante, bool>> predicate, Expression<Func<Comprobante, UniversalExtend>> source)
        {
            return _comprobanteRepository.SelectList(predicate, source);
        }

        /// <summary>
        /// Sin Guía de Remisión
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UniversalExtend> ComprobantePagos()
        {
            return _comprobanteRepository.ComprobantePagos();
        }

        /// <summary>
        /// Lista de Comprobantes excepto Guía de Remisión.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UniversalExtend> ListaComprobantes()
        {
            var listaItem = ComprobantePagos().ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        //public IEnumerable<Comprobante> Filter
        //    (Expression<Func<Comprobante, bool>> predicate,
        //    List<Expression<Func<Comprobante, object>>> includes)
        //{
        //    return _comprobanteRepository.Filter(predicate, includes);
        //}

        public IEnumerable<UniversalExtend> ListaComprobantes(Expression<Func<Comprobante,
            UniversalExtend>> source)
        {
            var listaItem = SelectList(source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public Comprobante Single(Expression<Func<Comprobante, bool>> predicate)
        {
            return _comprobanteRepository.Single(predicate);
        }

        public Comprobante Single(Expression<Func<Comprobante, bool>> predicate,
            List<Expression<Func<Comprobante, object>>> includes)
        {
            return _comprobanteRepository.Single(predicate, includes);
        }

        public void Create(Comprobante entity)
        {
            var result = _comprobanteValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.ComprobanteId != default(int))
                _comprobanteRepository.Update(entity);
            else
            {
                bool exist = _comprobanteRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Comprobante que intenta registrar ya existe.");
                _comprobanteRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Comprobante, bool>> predicate)
        {
            _comprobanteRepository.Delete(predicate);
        }

        public void AsignarIdentificaciones(Comprobante comprobante, List<TipoIdentificacion> identificaciones)
        {
            _comprobanteRepository.AsignarIdentificaciones(comprobante, identificaciones);
        }

        public void RemoveIdentificaciones(Comprobante comprobante, List<TipoIdentificacion> identificaciones)
        {
            _comprobanteRepository.RemoveIdentificaciones(comprobante, identificaciones);
        }
    }
}
