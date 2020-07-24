using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdDetalleComprobantePago
    {
        private readonly DetalleComprobantePagoRepository _detalleComprobantePagoRepository = new DetalleComprobantePagoRepository();
        private readonly ProductoRepository _productoRepository = new ProductoRepository();

        public void Agregar(DetalleComprobantePagoExtend entity)
        {
            var producto = _productoRepository.Single(x => x.ProductoId == entity.ProductoId,
            new List<Expression<Func<Producto, object>>>() {
                x=>x.Medida,
                x => x.TasaImpuestos,
                x => x.ProductoPrecios
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DetalleComprobantePagoExtend, DetalleOrdenVentaExtend>();
            });

            var config2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DetalleOrdenVentaExtend, DetalleComprobantePagoExtend>();
            });

            IMapper iMapper = config.CreateMapper();
            var destino = iMapper.Map<DetalleComprobantePagoExtend, DetalleOrdenVentaExtend>(entity);



            if (producto != null)
            {
                IMapper iMapper2 = config2.CreateMapper();

                var context = new DetalleVentaDinamico();

                if (producto.CalculoImportePorRangos)
                {
                    context.SetStrategy(new CalculadoraPorRangos(producto));
                    DetalleOrdenVentaExtend detalle = context.SeleccionaProducto(producto, destino);
                    var destino2 =
                        iMapper2.Map<DetalleOrdenVentaExtend, DetalleComprobantePagoExtend>(detalle);
                    _detalleComprobantePagoRepository.Agregar(destino2);
                }
                else
                {
                    context.SetStrategy(new CalculadoraClasica(producto));
                    DetalleOrdenVentaExtend detalle = context.SeleccionaProducto(producto, destino);
                    var destino2 =
                        iMapper2.Map<DetalleOrdenVentaExtend, DetalleComprobantePagoExtend>(detalle);
                    _detalleComprobantePagoRepository.Agregar(destino2);

                }
                entity.SumSubTotalIva = _detalleComprobantePagoRepository.SumaSubTotal();
                entity.SumValorIva = _detalleComprobantePagoRepository.SumaIva();
                entity.SumTotal = _detalleComprobantePagoRepository.SumaTotal();
                entity.SumSubtotalIvaCero = _detalleComprobantePagoRepository.SumaSubTotalCero();
                entity.SumTotal = _detalleComprobantePagoRepository.SumaTotal();
            }
            else
                return;
        }

        public void Remove(int id)
        {
            _detalleComprobantePagoRepository.Remove(id);
        }

        public decimal SumaSubTotal()
        {
            return _detalleComprobantePagoRepository.SumaSubTotal();
        }

        public decimal SumaSubTotalCero()
        {
            return _detalleComprobantePagoRepository.SumaSubTotalCero();
        }

        public decimal SumaIva()
        {
            return _detalleComprobantePagoRepository.SumaIva();
        }

        public decimal SumaTotal()
        {
            return _detalleComprobantePagoRepository.SumaTotal();
        }

        public List<DetalleComprobantePagoExtend> MostrarComprobantePago()
        {
            return _detalleComprobantePagoRepository.DetalleItemTemp;
        }

        public void Clean()
        {
            _detalleComprobantePagoRepository.Clean();
        }

        public DetalleComprobantePago Single(Expression<Func<DetalleComprobantePago, bool>> predicate,
            List<Expression<Func<DetalleComprobantePago, object>>> includes)
        {
            return _detalleComprobantePagoRepository.Single(predicate, includes);
        }
    }
}
