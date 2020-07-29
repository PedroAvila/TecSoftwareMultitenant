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
    public class SdNumeradorComprobante : ISdNumeradorComprobante
    {

        private readonly NumeradorRepository _numeradorRepository = new NumeradorRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<NumeradorComprobante, UniversalExtend>> source)
        {
            return await _numeradorRepository.SelectList(source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaNumerador
            (Expression<Func<NumeradorComprobante, UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<NumeradorComprobante, bool>> predicate,
            Expression<Func<NumeradorComprobante, UniversalExtend>> source)
        {
            return await _numeradorRepository.SelectList(predicate, source);
        }

        public async Task<NumeradorComprobante> Single(Expression<Func<NumeradorComprobante, bool>> predicate)
        {
            return await _numeradorRepository.Single(predicate);
        }

        public async Task<bool> Exist(Expression<Func<NumeradorComprobante, bool>> predicate)
        {
            return await _numeradorRepository.Exist(predicate);
        }

        public async Task Create(NumeradorComprobante entity)
        {
            if (entity.Id != default)
                await _numeradorRepository.Update(entity);
            else
            {
                bool exist =
                    await _numeradorRepository.Exist(
                        x => x.PuntoEmisionId == entity.PuntoEmisionId && x.ComprobanteId == entity.ComprobanteId);
                if (exist)
                    throw new CustomException("el numerador de Comprobante de Pago que intenta registrar ya existe.");
                await _numeradorRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<NumeradorComprobante, bool>> predicate)
        {
            await _numeradorRepository.Delete(predicate);
        }

        public async Task<string> NumeroSecuencial(int puntoEmision, int comprobante)
        {
            return await _numeradorRepository.NumeroSecuencial(puntoEmision, comprobante);
        }

        public async Task UpdateNumerador(NumeradorComprobante entity)
        {
            await _numeradorRepository.UpdateNumerador(entity);
        }
    }
}
