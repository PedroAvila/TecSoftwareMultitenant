using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IDetalleOrdenVenta<T> where T : class
    {
        List<DetalleOrdenVentaExtend> DetalleItemTemp { get; }

        void Agregar(DetalleOrdenVentaExtend entity);
        Task<IEnumerable<DetalleOrdenVentaExtend>> BuscarDetalleOrdenVenta(int id);
        void Clean();
        void Quitar(int indice);
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