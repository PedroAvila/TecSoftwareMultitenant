using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdDetalleOrdenVenta : ISdDetalleOrdenVenta
    {
        private readonly DetalleOrdenVentaRepository _ventaRepository = new DetalleOrdenVentaRepository();
        private readonly ProductoRepository _productoRepository = new ProductoRepository();

        public async Task Agregar(DetalleOrdenVentaExtend entity)
        {
            var producto = await _productoRepository.Single(x => x.ProductoId == entity.ProductoId,
                new List<Expression<Func<Producto, object>>>() {
                    x=>x.Medida,
                    //x => x.TasaImpuestos,
                    x => x.ProductoPrecios
                });

            if (producto != null)
            {
                var context = new DetalleVentaDinamico();

                if (producto.CalculoImportePorRangos)
                {
                    context.SetStrategy(new CalculadoraPorRangos(producto));
                    _ventaRepository.Agregar(await context.SeleccionaProducto(producto, entity));
                }
                else
                {
                    context.SetStrategy(new CalculadoraClasica(producto));
                    _ventaRepository.Agregar(await context.SeleccionaProducto(producto, entity));
                }
                entity.SumSubTotalIva = _ventaRepository.SumaSubTotal();
                entity.SumValorIva = _ventaRepository.SumaIva();
                entity.SumTotal = _ventaRepository.SumaTotal();
                entity.SumSubtotalIvaCero = _ventaRepository.SumaSubTotalCero();
                entity.SumTotal = _ventaRepository.SumaTotal();
                entity.SumaTotalDescuento = _ventaRepository.SumaTotalDescuento();
            }
            else
                return;
        }

        public void Remove(int id)
        {
            _ventaRepository.Remove(id);
        }

        public decimal SumaSubTotal()
        {
            return _ventaRepository.SumaSubTotal();
        }

        public decimal SumaTotalDescuento()
        {
            return _ventaRepository.SumaTotalDescuento();
        }

        public decimal SumaSubTotalCero()
        {
            return _ventaRepository.SumaSubTotalCero();
        }

        public decimal SumaIva()
        {
            return _ventaRepository.SumaIva();
        }

        public decimal SumaTotal()
        {
            return _ventaRepository.SumaTotal();
        }

        public List<DetalleOrdenVentaExtend> MostrarVentas()
        {
            return _ventaRepository.DetalleItemTemp;
        }

        public void Clean()
        {
            _ventaRepository.Clean();
        }

        public async Task Registrar(List<DetalleOrdenVenta> list)
        {

            await _ventaRepository.Registrar(list);
        }

        public async Task<List<DetalleOrdenVentaExtend>> SearchXFolio(int folio)
        {
            return await _ventaRepository.SearchXFolio(folio);
        }

        public async Task<IEnumerable<DetalleOrdenVentaExtend>> BuscarDetalleOrdenVenta(int id)
        {
            return await _ventaRepository.BuscarDetalleOrdenVenta(id);
        }

        public async Task Delete(Expression<Func<DetalleOrdenVenta, bool>> predicate)
        {
            await _ventaRepository.Delete(predicate);
        }

        public DetalleOrdenVentaExtend AplicarDescuento(DetalleOrdenVentaExtend entity)
        {
            entity.Precio -= entity.TotalDescuento;
            var importe = entity.Cantidad * entity.Precio;
            entity.SubTotalIva = Math.Round(importe * 10000M / (100M + entity.Iva)) / 100M;
            entity.ValorIva = importe - entity.SubTotalIva;
            return entity;
        }

        DetalleOrdenVentaExtend _detalle;
        public async Task ModificarCantidad(DetalleOrdenVentaExtend entity)
        {
            var producto = await _productoRepository.Single(x => x.ProductoId == entity.ProductoId,
                //new List<Expression<Func<Producto, object>>>() { x => x.TasaImpuestos, x => x.ProductoPrecios });
                new List<Expression<Func<Producto, object>>>() { x => x.ProductoPrecios });

            if (producto != null)
            {
                var context = new DetalleVentaDinamico();

                if (producto.CalculoImportePorRangos)
                {
                    context.SetStrategy(new CalculadoraPorRangos(producto));
                    _detalle = await context.SeleccionaProducto(producto, entity);
                }
                else
                {
                    context.SetStrategy(new CalculadoraClasica(producto));
                    _detalle = await context.SeleccionaProducto(producto, entity);
                }
                entity.ProductoPrecioId = _detalle.ProductoPrecioId;
                entity.Precio = _detalle.Precio;
                entity.SubTotalIva = _detalle.SubTotalIva;
                entity.ValorIva = _detalle.ValorIva;
                entity.SubTotalCero = _detalle.SubTotalCero;
            }
            else
                return;
        }


    }
}
