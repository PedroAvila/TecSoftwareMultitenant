using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class DetalleOrdenVentaRepository : BaseBusinessRepository<DetalleOrdenVenta>, IDetalleOrdenVenta<DetalleOrdenVenta>
    {
        private readonly List<DetalleOrdenVentaExtend> _ventaItem = new List<DetalleOrdenVentaExtend>();

        public List<DetalleOrdenVentaExtend> DetalleItemTemp => _ventaItem.ToList();

        public void Agregar(DetalleOrdenVentaExtend entity) //IDetalleOrdenVenta<DetalleOrdenVenta>
        {
            _ventaItem.Add(entity);
        }

        /// <summary>
        /// Sumarán todos los precios totales de los productos gravados con la tarifa de IVA vigente.
        /// </summary>
        /// <returns></returns>
        public decimal SumaSubTotal()
        {
            return _ventaItem.Sum(x => x.SubTotalIva);
        }

        public decimal SumaTotalDescuento()
        {
            return _ventaItem.Sum(x => x.TotalDescuento);
        }

        public decimal SumaSubTotalCero()
        {
            return _ventaItem.Sum(x => x.SubTotalCero);
        }

        public decimal SumaIva()
        {
            return _ventaItem.Sum(x => x.ValorIva);
        }

        public decimal SumaTotal()
        {
            return _ventaItem.Sum(x => x.SubTotalIva + x.SubTotalCero + x.ValorIce + x.ValorIva);
        }

        /// <summary>
        /// Quita un item del detalle de la grilla.
        /// </summary>
        /// <param name="indice">indice es el parámetro que identifica al registro a eliminar</param>
        public void Quitar(int indice)
        {
            if (_ventaItem.Count > 0)
                _ventaItem.RemoveAt(indice);
        }

        public void Remove(int id)
        {
            _ventaItem.RemoveAt(id);
        }

        public void Clean()
        {
            _ventaItem.Clear();
        }

        //public string MaxFolio()
        //{
        //    using (var context = new BusinessContext())
        //    {
        //        var result = (from v in context.DetalleVentas
        //            select v.VentaId).Max();
        //        var numMax = Convert.ToInt32(result) + 1;
        //        var number = $"{Convert.ToInt32(numMax):00000000}";
        //        return number;
        //    }
        //}

        public async Task Registrar(List<DetalleOrdenVenta> list)
        {
            using (var context = new BusinessContext())
            {
                //Venta
                foreach (var e in list)
                {
                    context.Entry(e).State = EntityState.Added;
                }
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Me oarece que no se esta utilizando este método.
        /// </summary>
        /// <param name="folio"></param>
        /// <returns></returns>
        public async Task<List<DetalleOrdenVentaExtend>> SearchXFolio(int folio)
        {
            using (var context = new BusinessContext())
            {
                var result = from v in context.DetalleOrdenVentas
                             join p in context.Productos on v.ProductoId equals p.ProductoId
                             join pp in context.ProductoPrecios on p.ProductoId equals pp.ProductoId
                             where v.OrdenVentaId == folio
                             select new DetalleOrdenVentaExtend()
                             {
                                 DetalleOrdenVentaId = v.DetalleOrdenVentaId,
                                 OrdenVentaId = v.OrdenVentaId,
                                 ProductoId = p.ProductoId,
                                 Descripcion = p.Nombre,
                                 Cantidad = v.Cantidad,
                                 ProductoPrecioId = pp.ProductoPrecioId,
                                 SubTotalIva = v.SubTotalIva,
                                 SubTotalCero = v.SubTotalCero,
                                 SubTotalNoObjetoIva = v.SubTotalNoObjetoIva,
                                 SubTotalExentoIva = v.SubTotalExentoIva,
                                 SubTotal = v.SubTotal,
                                 TotalDescuento = v.TotalDescuento,
                                 ValorIce = v.ValorIce,
                                 ValorIrbpnr = v.ValorIrbpnr,
                                 ValorIva = v.ValorIva
                             };
                return await result.ToListAsync();
            }
        }

        /// <summary>
        /// Método para buscar Detalles de ordenes de venta desde el form Venta.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DetalleOrdenVentaExtend>> BuscarDetalleOrdenVenta(int id)
        {
            using (var context = new BusinessContext())
            {
                var result = from dov in context.DetalleOrdenVentas
                             join p in context.Productos on dov.ProductoId equals p.ProductoId
                             join pp in context.ProductoPrecios on dov.ProductoPrecioId equals pp.ProductoPrecioId
                             where dov.OrdenVentaId == id
                             select new DetalleOrdenVentaExtend()
                             {
                                 DetalleOrdenVentaId = dov.DetalleOrdenVentaId,
                                 OrdenVentaId = dov.OrdenVentaId,
                                 ProductoPrecioId = dov.ProductoPrecioId,
                                 Precio = pp.Pvp,
                                 ProductoId = dov.ProductoId,
                                 Descripcion = p.Nombre,
                                 Cantidad = dov.Cantidad
                             };
                return await result.ToListAsync();
            }
        }

    }
}
