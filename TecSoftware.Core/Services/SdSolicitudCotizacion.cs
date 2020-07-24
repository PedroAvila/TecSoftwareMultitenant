using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Persistencia;

namespace TecSoftware.Core
{
    public class SdSolicitudCotizacion
    {
        private readonly SolicitudCotizacionRepository _solicitudCotizacionRepository = new SolicitudCotizacionRepository();
        private readonly SolicitudCotizacionValidator _solicitudCotizacionValidator = new SolicitudCotizacionValidator();

        public IEnumerable<UniversalExtend> SelectSolicitudCotizacion(CriteriaDocumento filter)
        {
            return _solicitudCotizacionRepository.SelectSolicitudCotizacion(filter);
        }

        public SolicitudCotizacion Single(Expression<Func<SolicitudCotizacion, bool>> predicate)
        {
            return _solicitudCotizacionRepository.Single(predicate);
        }

        public SolicitudCotizacion Single(Expression<Func<SolicitudCotizacion, bool>> predicate,
            List<Expression<Func<SolicitudCotizacion, object>>> includes)
        {
            return _solicitudCotizacionRepository.Single(predicate, includes);
        }

        public void Create(SolicitudCotizacion entity)
        {
            var result = _solicitudCotizacionValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.SolicitudCotizacionId != default)
                _solicitudCotizacionRepository.Update(entity);
            else
            {
                bool exist = _solicitudCotizacionRepository.Exist(x => x.SolicitudCotizacionId == entity.SolicitudCotizacionId);
                if (exist)
                    throw new CustomException("La Solicitud de Cotización que intenta registrar ya existe.");
                entity.NumeroCotizacion = _solicitudCotizacionRepository.GenerarCodigo();
                _solicitudCotizacionRepository.Create(entity);
            }
        }

        public void Registrar(SolicitudCotizacion entity)
        {
            _solicitudCotizacionRepository.Registrar(entity);
        }

        public void Delete(Expression<Func<SolicitudCotizacion, bool>> predicate)
        {
            _solicitudCotizacionRepository.Delete(predicate);
        }

        public IEnumerable<SolicitudCotizacionExtend> ListarSolicitudCotizacion(int solicitudCotizacionId)
        {
            return _solicitudCotizacionRepository.ListarSolicitudCotizacion(solicitudCotizacionId);
        }

        public bool Exist(Expression<Func<SolicitudCotizacion, bool>> predicate)
        {
            return _solicitudCotizacionRepository.Exist(predicate);
        }

        public void UpdateSolicitudCotizacion(int id, EstadoSolicitudCotizacion estado)
        {
            _solicitudCotizacionRepository.UpdateSolicitudCotizacion(id, estado);
        }
    }
}
