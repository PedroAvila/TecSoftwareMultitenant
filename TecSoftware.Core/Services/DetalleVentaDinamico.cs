using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{

    public class DetalleVentaDinamico
    {
        private readonly ProductoRepository _productoRepository = new ProductoRepository();

        private ICalculadoraTotales _strategy;

        public DetalleVentaDinamico()
        {

        }

        public void SetStrategy(ICalculadoraTotales strategy)
        {
            _strategy = strategy;
        }

        public async Task<DetalleOrdenVentaExtend> SeleccionaProducto(Producto producto, DetalleOrdenVentaExtend detalle)
        {
            //El método me debe de devolver un item(entidad) para agregarlo a una lista 
            //Y cargar el DGV
            //List<ProductoPrecio> precios = producto.ProductoPrecios.ToList();
            //ProductoPrecio p = ObtenerProducto(detalle.Cantidad, precios);
            //if (producto != null)
            //{
            //    //Obtengo el Id de la Presentación y la abreviación para mostrarlo en el asistente de venta
            //    //Y en el form donde se factura.
            //    var _producto = await _productoRepository.Single(x => x.ProductoId == producto.ProductoId,
            //        new List<Expression<Func<Producto, object>>> {
            //            x=>x.Presentacion
            //        });

            //    if (p != null)
            //    {
            //        List<TasaImpuesto> listTasaImuesto = producto.TasaImpuestos.ToList();
            //        if (listTasaImuesto.Any())
            //        {
            //            foreach (var item in listTasaImuesto)
            //            {
            //                if (item.ImpuestoId == 1 && item.Estado == TasaImpuestoStatus.Activo)
            //                    detalle.Iva = item.Tasa.Value;
            //            }
            //        }

            //        if (_producto.Presentacion != null)
            //        {
            //            decimal importe;
            //            if (detalle.Iva > 0)
            //            {
            //                if (producto.IncluyeImpuesto == IncluyeImpuesto.No)
            //                {
            //                    detalle.AbreviacionPresentacion = _producto.Presentacion.Abreviacion;
            //                    detalle.PresentacionId = _producto.Presentacion.PresentacionId;
            //                    detalle.ProductoPrecioId = p.ProductoPrecioId;
            //                    detalle.Precio = p.Pvp;
            //                    importe = _strategy.CalcularImporte(detalle.Cantidad, p).Value;
            //                    detalle.SubTotalIva = importe;
            //                    detalle.ValorIva = importe * (detalle.Iva / 100);
            //                }
            //                if (producto.IncluyeImpuesto == IncluyeImpuesto.Si)
            //                {
            //                    if (p != null)
            //                    {
            //                        detalle.PresentacionId = _producto.Presentacion.PresentacionId;
            //                        detalle.AbreviacionPresentacion = _producto.Presentacion.Abreviacion;
            //                        detalle.ProductoPrecioId = p.ProductoPrecioId;
            //                        detalle.Precio = p.Pvp;
            //                        importe = _strategy.CalcularImporte(detalle.Cantidad, p).Value;
            //                        detalle.SubTotalIva = Math.Round(importe * 10000M / (100M + detalle.Iva)) / 100M;
            //                        detalle.ValorIva = importe - detalle.SubTotalIva;
            //                    }
            //                }
            //            }
            //            if (detalle.Iva == 0)
            //            {
            //                detalle.AbreviacionPresentacion = _producto.Presentacion.Abreviacion;
            //                detalle.PresentacionId = _producto.Presentacion.PresentacionId;
            //                detalle.ProductoPrecioId = p.ProductoPrecioId;
            //                detalle.Precio = p.Pvp;
            //                importe = _strategy.CalcularImporte(detalle.Cantidad, p).Value;
            //                detalle.SubTotalCero = importe;
            //            }
            //        }
            //    }
            //}
            //return detalle;
            throw new NotImplementedException();
        }

        private ProductoPrecio ObtenerProducto(decimal cantidad,
            List<ProductoPrecio> precios)
        {
            foreach (ProductoPrecio p in precios)
            {
                if (cantidad < p.CantidadMinima)
                    continue;
                //Si estoy aquí, es porque la nueva cantidad es igual o superior
                //a la cantidad mínima.
                if (p.CantidadMaxima != null)
                {
                    if (cantidad <= p.CantidadMaxima)
                        return p;
                    else
                        continue;
                }
                else
                    return p;
            }
            return null;
        }
    }
}
