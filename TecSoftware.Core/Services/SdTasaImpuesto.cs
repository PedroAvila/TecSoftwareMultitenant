using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdTasaImpuesto
    {
        private readonly TasaImpuestoRepository _tarifaImpuestoRepository = new TasaImpuestoRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<TasaImpuesto, UniversalExtend>> source)
        {
            return await _tarifaImpuestoRepository.SelectList(source);
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

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<TasaImpuesto, bool>> predicate,
            Expression<Func<TasaImpuesto, UniversalExtend>> source)
        {
            return await _tarifaImpuestoRepository.SelectList(predicate, source);
        }

        public async Task<TasaImpuesto> Single(Expression<Func<TasaImpuesto, bool>> predicate)
        {
            return await _tarifaImpuestoRepository.Single(predicate);
        }

        public async Task Create(TasaImpuesto entity)
        {
            if (entity.TasaImpuestoId != default(int))
                await _tarifaImpuestoRepository.Update(entity);
            else
            {
                bool exist = await _tarifaImpuestoRepository.Exist(x => x.Concepto == entity.Concepto);
                if (exist)
                    throw new CustomException("El concepto que intenta registrar ya existe.");
                await _tarifaImpuestoRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<TasaImpuesto, bool>> predicate)
        {
            await _tarifaImpuestoRepository.Delete(predicate);
        }
    }
}
