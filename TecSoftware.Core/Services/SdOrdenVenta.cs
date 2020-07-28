using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdOrdenVenta
    {
        private readonly OrdenVentaRepository _ordenVentaRepository = new OrdenVentaRepository();
        private readonly SdPuntoEmision _sdPuntoEmision = new SdPuntoEmision();
        private readonly SdNumeradorOrdenVenta _sdNumeradorOrdenVenta = new SdNumeradorOrdenVenta();


        public async Task<string> CodigoNumerico()
        {
            return await _ordenVentaRepository.CodigoNumerico();
        }

        public async Task Create(OrdenVenta entity)
        {
            using (var scope = new TransactionScope())
            {
                var exist = await _sdNumeradorOrdenVenta.Exist(x => x.PuntoEmisionId == entity.PuntoEmisionId);
                if (!exist)
                    throw new CustomException("Debe crear el Numerador Orden de Venta.");
                if (entity.OrdenVentaId == default(int))
                {
                    entity.CodigoNumerico = await CodigoNumerico();
                    var serie = _sdPuntoEmision.NumeroSerie(entity.PuntoEmisionId);
                    var secuencial = await _sdNumeradorOrdenVenta.NumeroSecuencial(entity.PuntoEmisionId);
                    entity.NumeroComprobante = serie + secuencial;
                    await _ordenVentaRepository.Registrar(entity);
                    var numerador = new NumeradorOrdenVenta()
                    {
                        PuntoEmisionId = entity.PuntoEmisionId,
                        Secuencial = secuencial
                    };
                    await _sdNumeradorOrdenVenta.UpdateNumeradorOrdenVenta(numerador);
                }
                else
                {
                    await _ordenVentaRepository.Actualizar(entity);
                }
                scope.Complete();
            }
        }

        public async Task<IEnumerable<UniversalExtend>> SelectOrdenesDeVenta(CriteriaOrdenVenta filter)
        {
            return await _ordenVentaRepository.SelectOrdenesDeVenta(filter);
        }

        public async Task<OrdenVenta> Single(Expression<Func<OrdenVenta, bool>> predicate)
        {
            return await _ordenVentaRepository.Single(predicate);
        }
    }
}
