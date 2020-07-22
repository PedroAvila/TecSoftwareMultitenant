using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface ISolicitudCotizacion<T> where T : class
    {
        Task<string> GenerarCodigo();
        Task<IEnumerable<UniversalExtend>> SelectSolicitudCotizacion(CriteriaDocumento filter);
        Task Registrar(SolicitudCotizacion entity);
        Task<IEnumerable<SolicitudCotizacionExtend>> ListarSolicitudCotizacion(int solicitudCotizacionId);
        Task UpdateSolicitudCotizacion(int id, SolicitudCotizacionStatus estado);
    }
}
