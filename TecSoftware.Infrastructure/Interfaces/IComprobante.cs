using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IComprobante<T> where T : class
    {
        Task AsignarIdentificaciones(T comprobante, List<TipoIdentificacion> identificaciones);
        Task<IEnumerable<UniversalExtend>> ComprobantePagos();
        Task RemoveIdentificaciones(T comprobante, List<TipoIdentificacion> identificaciones);
    }
}