using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdSolicitudCotizacion
    {
        Task Create(SolicitudCotizacion entity);
        Task Delete(Expression<Func<SolicitudCotizacion, bool>> predicate);
        Task<bool> Exist(Expression<Func<SolicitudCotizacion, bool>> predicate);
        Task<IEnumerable<SolicitudCotizacionExtend>> ListarSolicitudCotizacion(int solicitudCotizacionId);
        Task Registrar(SolicitudCotizacion entity);
        Task<IEnumerable<UniversalExtend>> SelectSolicitudCotizacion(CriteriaDocumento filter);
        Task<SolicitudCotizacion> Single(Expression<Func<SolicitudCotizacion, bool>> predicate);
        Task<SolicitudCotizacion> Single(Expression<Func<SolicitudCotizacion, bool>> predicate, List<Expression<Func<SolicitudCotizacion, object>>> includes);
        Task UpdateSolicitudCotizacion(int id, SolicitudCotizacionStatus estado);
    }
}