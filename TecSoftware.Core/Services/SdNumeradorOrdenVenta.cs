using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdNumeradorOrdenVenta
    {
        private readonly NumeradorOrdenVentaRepository _numeradorOrdenVentaRepository =
            new NumeradorOrdenVentaRepository();
        private readonly NumeradorOrdenVentaValidator _numeradorOrdenVentaValidator = new NumeradorOrdenVentaValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<NumeradorOrdenVenta, UniversalExtend>> source)
        {
            return _numeradorOrdenVentaRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList
            (Expression<Func<NumeradorOrdenVenta, bool>> predicate, Expression<Func<NumeradorOrdenVenta, UniversalExtend>> source)
        {
            return _numeradorOrdenVentaRepository.SelectList(predicate, source);
        }

        public IEnumerable<UniversalExtend> ListaNumeradorOrdenVentas
            (Expression<Func<NumeradorOrdenVenta, UniversalExtend>> source)
        {
            var listaItem = SelectList(source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public NumeradorOrdenVenta Single(Expression<Func<NumeradorOrdenVenta, bool>> predicate)
        {
            return _numeradorOrdenVentaRepository.Single(predicate);
        }

        public bool Exist(Expression<Func<NumeradorOrdenVenta, bool>> predicate)
        {
            return _numeradorOrdenVentaRepository.Exist(predicate);

        }

        public void Create(NumeradorOrdenVenta entity)
        {
            var result = _numeradorOrdenVentaValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.Id != default(int))
                _numeradorOrdenVentaRepository.Update(entity);
            else
            {
                bool exist = _numeradorOrdenVentaRepository.Exist(x => x.Serie == entity.Serie);
                if (exist)
                    throw new CustomException("el numerador de Orden de venta que intenta registrar ya existe.");
                _numeradorOrdenVentaRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<NumeradorOrdenVenta, bool>> predicate)
        {
            _numeradorOrdenVentaRepository.Delete(predicate);
        }

        public string NumeroSecuencial(int puntoEmision)
        {
            return _numeradorOrdenVentaRepository.NumeroSecuencial(puntoEmision);
        }

        public void UpdateNumeradorOrdenVenta(NumeradorOrdenVenta entity)
        {
            _numeradorOrdenVentaRepository.UpdateNumeradorOrdenVenta(entity);
        }
    }
}
