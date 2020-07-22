using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IComprobantePago<T> where T : class
    {
        Task<string> CodigoNumerico();
        Task<IEnumerable<FacturaExtend>> ListarFactura(int comprobantePagoId);
        Task Registrar(T entity);
    }
}