using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdComprobantePago
    {
        Task<string> CodigoNumerico();
        Task Create(ComprobantePago entity, List<DetalleOrdenVenta> listDetalleOrdenVenta);
        Task<IEnumerable<FacturaExtend>> ListarFactura(int comprobantePagoId);
    }
}