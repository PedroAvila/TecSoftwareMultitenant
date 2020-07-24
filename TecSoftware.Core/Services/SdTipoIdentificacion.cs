using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdTipoIdentificacion
    {
        private readonly TipoIdentificacionRepository _tipoIdentificacionRepository = new TipoIdentificacionRepository();
        private readonly TipoIdentificacionValidator _tipoIdentificacionValidator = new TipoIdentificacionValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<TipoIdentificacion, UniversalExtend>> source)
        {
            return _tipoIdentificacionRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> ListaIdentificacionXCodigo()
        {
            var listaItem = ListaXCodigo().ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public List<ICollection<TipoIdentificacion>> IdentificacionXComprobante(int id)
        {
            return _tipoIdentificacionRepository.IdentificacionXComprobante(id);
        }

        public IEnumerable<TipoIdentificacionExtend> ListaVinculacionDatos
            (Expression<Func<TipoIdentificacion, TipoIdentificacionExtend>> source)
        {
            return _tipoIdentificacionRepository.ListaVinculacionDatos(source);
        }

        public IEnumerable<UniversalExtend> ListaXCodigo()
        {
            return _tipoIdentificacionRepository.ListaIdentificacionXCodigo();
        }

        public TipoIdentificacion Single(Expression<Func<TipoIdentificacion, bool>> predicate)
        {
            return _tipoIdentificacionRepository.Single(predicate);
        }

        public void Create(TipoIdentificacion entity)
        {
            var result = _tipoIdentificacionValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.TipoIdentificacionId != default(int))
                _tipoIdentificacionRepository.Update(entity);
            else
            {
                bool exist = _tipoIdentificacionRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Tipo de Identificación que intenta registrar ya existe.");
                _tipoIdentificacionRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<TipoIdentificacion, bool>> predicate)
        {
            _tipoIdentificacionRepository.Delete(predicate);
        }


    }
}
