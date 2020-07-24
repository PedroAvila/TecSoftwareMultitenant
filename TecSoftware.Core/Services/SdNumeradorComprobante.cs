using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdNumeradorComprobante
    {

        private readonly NumeradorRepository _numeradorRepository = new NumeradorRepository();
        private readonly NumeradorComprobanteValidator _numeradorComprobanteValidator =
            new NumeradorComprobanteValidator();
        public IEnumerable<UniversalExtend> SelectList(Expression<Func<NumeradorComprobante, UniversalExtend>> source)
        {
            return _numeradorRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> ListaNumerador
            (Expression<Func<NumeradorComprobante, UniversalExtend>> source)
        {
            var listaItem = SelectList(source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public IEnumerable<UniversalExtend> SelectList
            (Expression<Func<NumeradorComprobante, bool>> predicate,
            Expression<Func<NumeradorComprobante, UniversalExtend>> source)
        {
            return _numeradorRepository.SelectList(predicate, source);
        }

        public NumeradorComprobante Single(Expression<Func<NumeradorComprobante, bool>> predicate)
        {
            return _numeradorRepository.Single(predicate);
        }

        public bool Exist(Expression<Func<NumeradorComprobante, bool>> predicate)
        {
            return _numeradorRepository.Exist(predicate);
        }

        public void Create(NumeradorComprobante entity)
        {
            var result = _numeradorComprobanteValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.Id != default)
                _numeradorRepository.Update(entity);
            else
            {
                bool exist =
                    _numeradorRepository.Exist(
                        x => x.PuntoEmisionId == entity.PuntoEmisionId && x.ComprobanteId == entity.ComprobanteId);
                if (exist)
                    throw new CustomException("el numerador de Comprobante de Pago que intenta registrar ya existe.");
                _numeradorRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<NumeradorComprobante, bool>> predicate)
        {
            _numeradorRepository.Delete(predicate);
        }

        public string NumeroSecuencial(int puntoEmision, int comprobante)
        {
            return _numeradorRepository.NumeroSecuencial(puntoEmision, comprobante);
        }

        public void UpdateNumerador(NumeradorComprobante entity)
        {
            _numeradorRepository.UpdateNumerador(entity);
        }
    }
}
