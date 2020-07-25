using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdPuntoEmision
    {
        private readonly PuntoEmisionRepository _puntoEmisionRepository = new PuntoEmisionRepository();
        private readonly PuntoEmisionValidator _puntoEmisionValidator = new PuntoEmisionValidator();

        public IEnumerable<PuntoEmision> GetAll()
        {
            return _puntoEmisionRepository.GetAll();
        }

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<PuntoEmision, UniversalExtend>> source)
        {
            return _puntoEmisionRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList
            (Expression<Func<PuntoEmision, bool>> predicate, Expression<Func<PuntoEmision, UniversalExtend>> source)
        {
            return _puntoEmisionRepository.SelectList(predicate, source);
        }

        public IEnumerable<UniversalExtend> ListaPuntoEmision(Expression<Func<PuntoEmision, bool>> predicate,
            Expression<Func<PuntoEmision, UniversalExtend>> source)
        {
            var listaItem = SelectList(predicate, source).ToList();
            listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
            return listaItem;
        }

        public IEnumerable<PuntoEmision> Filter
            (Expression<Func<PuntoEmision, bool>> predicate, List<Expression<Func<PuntoEmision, object>>> includes)
        {
            return _puntoEmisionRepository.Filter(predicate, includes);
        }

        public PuntoEmision Single(Expression<Func<PuntoEmision, bool>> predicate)
        {
            return _puntoEmisionRepository.Single(predicate);
        }

        public bool Exist(Expression<Func<PuntoEmision, bool>> predicate)
        {
            return _puntoEmisionRepository.Exist(predicate);
        }

        public void Create(PuntoEmision entity)
        {
            var result = _puntoEmisionValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.PuntoEmisionId != default(int))
                _puntoEmisionRepository.Update(entity);
            else
            {
                bool exist =
                    _puntoEmisionRepository.Exist(
                        x => x.EstablecimientoId == entity.EstablecimientoId && x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Punto de emisión que intenta registrar ya existe.");
                _puntoEmisionRepository.Create(entity);
            }
        }

        public void Update(PuntoEmision entity)
        {
            _puntoEmisionRepository.Update(entity);
        }

        public void UpdatePuntoEmision(PuntoEmision entity)
        {
            _puntoEmisionRepository.UpdatePuntoEmision(entity);
        }

        public void Delete(Expression<Func<PuntoEmision, bool>> predicate)
        {
            _puntoEmisionRepository.Delete(predicate);
        }

        public IEnumerable<UniversalExtend> ListaPtoEmision()
        {
            return _puntoEmisionRepository.ListaPtoEmision();
        }

        public IEnumerable<UniversalExtend> ListaPtoEmision(int id)
        {
            return _puntoEmisionRepository.ListaPtoEmision(id);
        }

        public async Task<string> NumeroSerie(int puntoEmision)
        {
            return await _puntoEmisionRepository.NumeroSerie(puntoEmision);
        }

    }
}
