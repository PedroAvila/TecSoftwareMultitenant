using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdDetalleOrdenVenta
    {
        Task Agregar(DetalleOrdenVentaExtend entity);
        DetalleOrdenVentaExtend AplicarDescuento(DetalleOrdenVentaExtend entity);
        Task<IEnumerable<DetalleOrdenVentaExtend>> BuscarDetalleOrdenVenta(int id);
        void Clean();
        Task Delete(Expression<Func<DetalleOrdenVenta, bool>> predicate);
        Task ModificarCantidad(DetalleOrdenVentaExtend entity);
        List<DetalleOrdenVentaExtend> MostrarVentas();
        Task Registrar(List<DetalleOrdenVenta> list);
        void Remove(int id);
        Task<List<DetalleOrdenVentaExtend>> SearchXFolio(int folio);
        decimal SumaIva();
        decimal SumaSubTotal();
        decimal SumaSubTotalCero();
        decimal SumaTotal();
        decimal SumaTotalDescuento();
    }
}