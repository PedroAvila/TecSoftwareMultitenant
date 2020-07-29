using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Persistencia;

namespace TecSoftware.Core
{
    public class SdSolicitudCotizacion : ISdSolicitudCotizacion
    {
        private readonly SolicitudCotizacionRepository _solicitudCotizacionRepository =
            new SolicitudCotizacionRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectSolicitudCotizacion(CriteriaDocumento filter)
        {
            return await _solicitudCotizacionRepository.SelectSolicitudCotizacion(filter);
        }

        public async Task<SolicitudCotizacion> Single(Expression<Func<SolicitudCotizacion, bool>> predicate)
        {
            return await _solicitudCotizacionRepository.Single(predicate);
        }

        public async Task<SolicitudCotizacion> Single(Expression<Func<SolicitudCotizacion, bool>> predicate,
            List<Expression<Func<SolicitudCotizacion, object>>> includes)
        {
            return await _solicitudCotizacionRepository.Single(predicate, includes);
        }

        public async Task Create(SolicitudCotizacion entity)
        {
            if (entity.SolicitudCotizacionId != default)
                await _solicitudCotizacionRepository.Update(entity);
            else
            {
                bool exist = await _solicitudCotizacionRepository
                    .Exist(x => x.SolicitudCotizacionId == entity.SolicitudCotizacionId);
                if (exist)
                    throw new CustomException("La Solicitud de Cotización que intenta registrar ya existe.");
                entity.NumeroCotizacion = await _solicitudCotizacionRepository.GenerarCodigo();
                await _solicitudCotizacionRepository.Create(entity);
            }
        }

        public async Task Registrar(SolicitudCotizacion entity)
        {
            await _solicitudCotizacionRepository.Registrar(entity);
        }

        public async Task Delete(Expression<Func<SolicitudCotizacion, bool>> predicate)
        {
            await _solicitudCotizacionRepository.Delete(predicate);
        }

        public async Task<IEnumerable<SolicitudCotizacionExtend>> ListarSolicitudCotizacion(int solicitudCotizacionId)
        {
            return await _solicitudCotizacionRepository.ListarSolicitudCotizacion(solicitudCotizacionId);
        }

        public async Task<bool> Exist(Expression<Func<SolicitudCotizacion, bool>> predicate)
        {
            return await _solicitudCotizacionRepository.Exist(predicate);
        }

        public async Task UpdateSolicitudCotizacion(int id, SolicitudCotizacionStatus estado)
        {
            await _solicitudCotizacionRepository.UpdateSolicitudCotizacion(id, estado);
        }
    }
}
