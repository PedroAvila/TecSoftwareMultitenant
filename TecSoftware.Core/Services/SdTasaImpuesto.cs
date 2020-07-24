using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdTasaImpuesto
    {
        private readonly TasaImpuestoRepository _tarifaImpuestoRepository = new TasaImpuestoRepository();
        private readonly TasaImpuestoValidator _tarifaImpuestoValidator = new TasaImpuestoValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<TasaImpuesto, UniversalExtend>> source)
        {
            return _tarifaImpuestoRepository.SelectList(source);
        }

        public List<TasaImpuesto> MostrarTasaImpuestos()
        {
            return _tarifaImpuestoRepository.DetalleItemTemp;
        }

        public void Agregar(TasaImpuesto entity)
        {
            _tarifaImpuestoRepository.Agregar(entity);
        }

        public void CleanTasaImpuesto()
        {
            _tarifaImpuestoRepository.CleanTasaImpuesto();
        }

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<TasaImpuesto, bool>> predicate,
            Expression<Func<TasaImpuesto, UniversalExtend>> source)
        {
            return _tarifaImpuestoRepository.SelectList(predicate, source);
        }

        public TasaImpuesto Single(Expression<Func<TasaImpuesto, bool>> predicate)
        {
            return _tarifaImpuestoRepository.Single(predicate);
        }

        public void Create(TasaImpuesto entity)
        {
            var result = _tarifaImpuestoValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.TasaImpuestoId != default(int))
                _tarifaImpuestoRepository.Update(entity);
            else
            {
                bool exist = _tarifaImpuestoRepository.Exist(x => x.Concepto == entity.Concepto);
                if (exist)
                    throw new CustomException("El concepto que intenta registrar ya existe.");
                _tarifaImpuestoRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<TasaImpuesto, bool>> predicate)
        {
            _tarifaImpuestoRepository.Delete(predicate);
        }
    }
}
