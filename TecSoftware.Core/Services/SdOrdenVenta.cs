using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Transactions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;
using TecSoftware.ServiciosDominio;

namespace TecSoftware.Core
{
    public class SdOrdenVenta
    {
        private readonly OrdenVentaRepository _ordenVentaRepository = new OrdenVentaRepository();
        private readonly SdPuntoEmision _sdPuntoEmision = new SdPuntoEmision();
        private readonly SdNumeradorOrdenVenta _sdNumeradorOrdenVenta = new SdNumeradorOrdenVenta();
        private readonly VentaValidator _ventaValidator = new VentaValidator();
        private readonly OrdenVentaValidator _ordeVentaValidator = new OrdenVentaValidator();


        public void Confirmar(OrdenVenta entity)
        {
            var result = _ventaValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
        }

        public string CodigoNumerico()
        {
            return _ordenVentaRepository.CodigoNumerico();
        }

        public void Create(OrdenVenta entity)
        {
            using (var scope = new TransactionScope())
            {
                var result = _ordeVentaValidator.Validate(entity);
                if (!result.IsValid)
                    throw new CustomException(Validator.GetErrorMessages(result.Errors));

                var exist = _sdNumeradorOrdenVenta.Exist(x => x.PuntoEmisionId == entity.PuntoEmisionId);
                if (!exist)
                    throw new CustomException("Debe crear el Numerador Orden de Venta.");
                if (entity.OrdenVentaId == default(int))
                {
                    entity.CodigoNumerico = CodigoNumerico();
                    var serie = _sdPuntoEmision.NumeroSerie(entity.PuntoEmisionId);
                    var secuencial = _sdNumeradorOrdenVenta.NumeroSecuencial(entity.PuntoEmisionId);
                    entity.NumeroComprobante = serie + secuencial;
                    _ordenVentaRepository.Registrar(entity);
                    var numerador = new NumeradorOrdenVenta()
                    {
                        PuntoEmisionId = entity.PuntoEmisionId,
                        Secuencial = secuencial
                    };
                    _sdNumeradorOrdenVenta.UpdateNumeradorOrdenVenta(numerador);
                }
                else
                {
                    _ordenVentaRepository.Actualizar(entity);
                }
                scope.Complete();
            }
        }

        public IEnumerable<UniversalExtend> SelectOrdenesDeVenta(CriteriaOrdenVenta filter)
        {
            return _ordenVentaRepository.SelectOrdenesDeVenta(filter);
        }

        public OrdenVenta Single(Expression<Func<OrdenVenta, bool>> predicate)
        {
            return _ordenVentaRepository.Single(predicate);
        }

    }
}
