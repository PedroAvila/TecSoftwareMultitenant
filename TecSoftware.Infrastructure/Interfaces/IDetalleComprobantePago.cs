using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IDetalleComprobantePago<T> where T : class
    {
        List<DetalleComprobantePagoExtend> DetalleItemTemp { get; }

        Task Agregar(DetalleComprobantePagoExtend entity);
        void Clean();
        void Quitar(int indice);
        void Remove(int id);
        decimal SumaIva();
        decimal SumaSubTotal();
        decimal SumaSubTotalCero();
        decimal SumaTotal();
    }
}