using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdRol
    {
        private readonly RolRepository _rolRepository = new RolRepository();
        private readonly RolValidator _rolValidator = new RolValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Rol, UniversalExtend>> source)
        {
            return _rolRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> ListaRoles(Expression<Func<Rol, UniversalExtend>> source)
        {
            var listItem = SelectList(source).ToList();
            listItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<Seleccione>>" });
            return listItem;
        }

        public void Create(Rol entity)
        {
            var result = _rolValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.RolId != default)
                _rolRepository.Update(entity);
            else
            {
                var exist = _rolRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La categoría que intenta registrar ya existe.");
                _rolRepository.Create(entity);
            }
        }

        public Rol Single(Expression<Func<Rol, bool>> predicate)
        {
            return _rolRepository.Single(predicate);
        }

        public Rol Single(Expression<Func<Rol, bool>> predicate,
            List<Expression<Func<Rol, object>>> includes)
        {
            return _rolRepository.Single(predicate, includes);
        }

        public IEnumerable<Rol> Filter(Expression<Func<Rol, bool>> predicate,
            List<Expression<Func<Rol, object>>> includes)
        {
            return _rolRepository.Filter(predicate, includes);
        }

        public void Delete(Expression<Func<Rol, bool>> predicate)
        {
            _rolRepository.Delete(predicate);
        }

        public void AsignarFunciones(Rol rol, List<Funcion> funciones)
        {
            _rolRepository.AsignarFunciones(rol, funciones);
        }

        public void RemoveFunciones(Rol rol, List<Funcion> funciones)
        {
            _rolRepository.RemoveFunciones(rol, funciones);
        }


    }
}
