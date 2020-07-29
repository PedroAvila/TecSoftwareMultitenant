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
    public class SdNumeradorOrdenVenta : ISdNumeradorOrdenVenta
    {
        private readonly NumeradorOrdenVentaRepository _numeradorOrdenVentaRepository =
            new NumeradorOrdenVentaRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<NumeradorOrdenVenta, UniversalExtend>> source)
        {
            return await _numeradorOrdenVentaRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<NumeradorOrdenVenta, bool>> predicate, Expression<Func<NumeradorOrdenVenta, UniversalExtend>> source)
        {
            return await _numeradorOrdenVentaRepository.SelectList(predicate, source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaNumeradorOrdenVentas
            (Expression<Func<NumeradorOrdenVenta, UniversalExtend>> source)
        {
            var listaItem = Task.Run(() => SelectList(source)).Result;
            listaItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return (Task<IEnumerable<UniversalExtend>>)listaItem;
        }

        public async Task<NumeradorOrdenVenta> Single(Expression<Func<NumeradorOrdenVenta, bool>> predicate)
        {
            return await _numeradorOrdenVentaRepository.Single(predicate);
        }

        public async Task<bool> Exist(Expression<Func<NumeradorOrdenVenta, bool>> predicate)
        {
            return await _numeradorOrdenVentaRepository.Exist(predicate);

        }

        public async Task Create(NumeradorOrdenVenta entity)
        {

            if (entity.Id != default(int))
                await _numeradorOrdenVentaRepository.Update(entity);
            else
            {
                bool exist = await _numeradorOrdenVentaRepository.Exist(x => x.Serie == entity.Serie);
                if (exist)
                    throw new CustomException("el numerador de Orden de venta que intenta registrar ya existe.");
                await _numeradorOrdenVentaRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<NumeradorOrdenVenta, bool>> predicate)
        {
            await _numeradorOrdenVentaRepository.Delete(predicate);
        }

        public async Task<string> NumeroSecuencial(int puntoEmision)
        {
            return await _numeradorOrdenVentaRepository.NumeroSecuencial(puntoEmision);
        }

        public async Task UpdateNumeradorOrdenVenta(NumeradorOrdenVenta entity)
        {
            await _numeradorOrdenVentaRepository.UpdateNumeradorOrdenVenta(entity);
        }
    }
}
