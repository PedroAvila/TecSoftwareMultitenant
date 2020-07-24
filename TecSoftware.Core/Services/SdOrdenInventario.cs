using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdOrdenInventario
    {
        public readonly OrdenInventarioRepository _ordenInventarioRepository = new OrdenInventarioRepository();
        private readonly OrdenInventarioValidator _ordenInventarioValidator = new OrdenInventarioValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<OrdenInventario, UniversalExtend>> source)
        {
            return _ordenInventarioRepository.SelectList(source);
        }

        public void Create(OrdenInventario entity)
        {
            var result = _ordenInventarioValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.OrdenInventarioId != default)
                _ordenInventarioRepository.Update(entity);
            else
            {
                var exist = _ordenInventarioRepository.Exist(x => x.NumeroOrden == entity.NumeroOrden);
                if (exist)
                    throw new CustomException("La Orden de Inventario que intenta registrar ya existe.");
                entity.NumeroOrden = _ordenInventarioRepository.GenerarCodigo();
                _ordenInventarioRepository.Create(entity);
            }
        }

        public OrdenInventario Single(Expression<Func<OrdenInventario, bool>> predicate)
        {
            return _ordenInventarioRepository.Single(predicate);
        }

        public OrdenInventario Single(Expression<Func<OrdenInventario, bool>> predicate,
            List<Expression<Func<OrdenInventario, object>>> includes)
        {
            return _ordenInventarioRepository.Single(predicate, includes);
        }

        public void Delete(Expression<Func<OrdenInventario, bool>> predicate)
        {
            _ordenInventarioRepository.Delete(predicate);
        }

        public IEnumerable<UniversalExtend> SelectOrdenesInventario(CriteriaOrdenInventario filter)
        {
            return _ordenInventarioRepository.SelectOrdenesInventario(filter);
        }
    }
}
