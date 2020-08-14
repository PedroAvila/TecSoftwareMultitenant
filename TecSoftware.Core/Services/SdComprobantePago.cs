using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdComprobantePago : ISdComprobantePago
    {
        private readonly SdPuntoEmision _sdPuntoEmision = new SdPuntoEmision();
        private readonly SdDetalleOrdenVenta _sdDetalleOrdenVenta = new SdDetalleOrdenVenta();
        private readonly SdNumeradorComprobante _sdNumerador = new SdNumeradorComprobante();
        private readonly ComprobantePagoRepository _comprobantePagoRepository = new ComprobantePagoRepository();
        private readonly SdDetalleComprobantePago _sdDetalleComprobantePago = new SdDetalleComprobantePago();
        private readonly SdProducto _sdProducto = new SdProducto();
        private readonly SdMovimientoCaja _sdMovimientoCaja = new SdMovimientoCaja();
        private readonly SdOrdenVenta _sdOrdenVenta = new SdOrdenVenta();
        private readonly SdImpuestoVenta _sdImpuestoVenta = new SdImpuestoVenta();
        private readonly SdOperacion _sdOperacion = new SdOperacion();
        private readonly IMapper _mapper;


        /// <summary>
        /// El código númerico de un comprobante de pago es de 8 digitos.
        /// </summary>
        /// <returns></returns>
        public async Task<string> CodigoNumerico()
        {
            return await _comprobantePagoRepository.CodigoNumerico();
        }

        //CORREJIR DESPUES DE CREAR LA DB
        public async Task Create(ComprobantePago entity, List<DetalleOrdenVenta> listDetalleOrdenVenta)
        {
            using (var scope = new TransactionScope())
            {
                //var result = _ordeVentaValidator.Validate(entity);
                //if (!result.IsValid)
                //    throw new CustomException(Validator.GetErrorMessages(result.Errors));

                bool exist = await _sdNumerador.Exist(x => x.PuntoEmisionId == entity.PuntoEmisionId);
                if (!exist)
                    throw new CustomException("Debe crear el Numerador del Comprobante de Pago.");
                if (entity.ComprobantePagoId == default(int))
                {
                    entity.CodigoNumerico = await CodigoNumerico();
                    var serie = await _sdPuntoEmision.NumeroSerie(entity.PuntoEmisionId);
                    var secuencial = await _sdNumerador.NumeroSecuencial(entity.PuntoEmisionId, entity.ComprobanteId);
                    entity.NumeroComprobante = serie + secuencial;

                    var ordenVentaId = listDetalleOrdenVenta.Select(x => x.OrdenVentaId).ToArray();
                    int id = ordenVentaId[0];
                    if (id == 0)
                    {
                        var ordenVenta1 = new OrdenVenta()
                        {
                            FechaEmision = entity.FechaEmision,
                            FechaEntrega = entity.FechaEmision,
                            ClienteId = entity.ClienteId,
                            UsuarioId = entity.UsuarioId,
                            PuntoEmisionId = entity.PuntoEmisionId,
                            Total = entity.Total,
                            Estado = OrdenVentaStatus.Atendido,
                            DetalleOrdenVentas = listDetalleOrdenVenta
                        };
                        await _sdOrdenVenta.Create(ordenVenta1);
                    }
                    else
                    {
                        var encontradoOV = await _sdOrdenVenta.Single(x => x.OrdenVentaId == id);
                        var ordenVenta2 = new OrdenVenta()
                        {
                            OrdenVentaId = ordenVentaId[0],
                            FechaEmision = encontradoOV.FechaEmision,
                            FechaEntrega = entity.FechaEmision,
                            CodigoNumerico = encontradoOV.CodigoNumerico,
                            NumeroComprobante = encontradoOV.NumeroComprobante,
                            ClienteId = entity.ClienteId,
                            UsuarioId = encontradoOV.UsuarioId,
                            PuntoEmisionId = entity.PuntoEmisionId,
                            Total = entity.Total,
                            Estado = OrdenVentaStatus.Atendido,
                            DetalleOrdenVentas = listDetalleOrdenVenta
                        };
                        await _sdOrdenVenta.Create(ordenVenta2);
                    }

                    //var listDetOrdenVenta = _sdDetalleOrdenVenta.SearchXFolio(ordenVenta.OrdenVentaId);
                    var listDest = _mapper.Map<List<DetalleOrdenVenta>, List<DetalleComprobantePago>>(listDetalleOrdenVenta);

                    var cp = new ComprobantePago()
                    {
                        ComprobantePagoId = entity.ComprobanteId,
                        CodigoNumerico = entity.CodigoNumerico,
                        NumeroComprobante = entity.NumeroComprobante,
                        ClienteId = entity.ClienteId,
                        UsuarioId = entity.UsuarioId,
                        FechaEmision = entity.FechaEmision,
                        PuntoEmisionId = entity.PuntoEmisionId,
                        ComprobanteId = entity.ComprobanteId,
                        TipoIdentificacionId = entity.TipoIdentificacionId,
                        FormaPagoId = entity.FormaPagoId,
                        Estado = entity.Estado, //Cancelado
                        Total = entity.Total,
                        DetalleComprobantePagos = listDest
                    };

                    await _comprobantePagoRepository.Registrar(cp);
                    entity.ComprobantePagoId = cp.ComprobantePagoId;
                    foreach (var item in cp.DetalleComprobantePagos)
                    {
                        var tasaimpuesto = await _sdProducto.Single(x => x.ProductoId == item.ProductoId,
                            new List<Expression<Func<Producto, object>>>()
                            {
                                //x => x.TasaImpuestos
                            });

                        //var listImpuesto = tasaimpuesto.TasaImpuestos.ToList();
                        //var y = listImpuesto.FirstOrDefault();
                        //if (y != null)
                        //{
                        //    var impuestoVenta = new ImpuestoVenta()
                        //    {
                        //        DetalleComprobantePagoId = item.DetalleComprobantePagoId,
                        //        TasaImpuestoId = y.TasaImpuestoId
                        //    };
                        //    await _sdImpuestoVenta.Create(impuestoVenta);
                        //}
                    }

                    var numerador = new NumeradorComprobante()
                    {
                        PuntoEmisionId = cp.PuntoEmisionId,
                        ComprobanteId = cp.ComprobanteId,
                        Secuencial = secuencial
                    };
                    await _sdNumerador.UpdateNumerador(numerador);

                    //Obtener operacionId
                    var operacion = await _sdOperacion.Single(x => x.PuntoEmisionId == entity.PuntoEmisionId
                    && x.OperacionStatus == OperacionCaja.Abrir);
                    if (operacion != null)
                    {
                        var movimientoCaja = new MovimientoCaja()
                        {
                            OperacionId = operacion.OperacionId,
                            ComprobantePagoId = cp.ComprobantePagoId,
                            UsuarioId = cp.UsuarioId,
                            TipoMovimiento = MovimientoCajaType.Ingreso,
                            Fecha = entity.FechaEmision,
                            //Concepto = txtConcepto.Text,
                            //MontoInicial = montoInicial,
                            Ingreso = entity.Total
                            //Egreso = montoEgreso
                        };
                        await _sdMovimientoCaja.Create(movimientoCaja);
                    }
                }
                scope.Complete();
            }
        }

        public async Task<IEnumerable<FacturaExtend>> ListarFactura(int comprobantePagoId)
        {
            return await _comprobantePagoRepository.ListarFactura(comprobantePagoId);
        }
    }
}
