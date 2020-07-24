using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProveedor
    {
        private readonly ProveedorRepository _proveedorRepository = new ProveedorRepository();
        private readonly ProveedorValidator _proveedorValidator = new ProveedorValidator();

        public List<Proveedor> MostrarProveedores()
        {
            return _proveedorRepository.DetalleItemTemp;
        }

        public void Agregar(Proveedor entity)
        {
            _proveedorRepository.Agregar(entity);
        }

        public void CleanProveedor()
        {
            _proveedorRepository.CleanProveedor();
        }

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Proveedor, UniversalExtend>> source)
        {
            return _proveedorRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Proveedor, bool>> predicate,
            Expression<Func<Proveedor, UniversalExtend>> source)
        {
            return _proveedorRepository.SelectList(predicate, source);
        }

        public Proveedor Single(Expression<Func<Proveedor, bool>> predicate)
        {
            return _proveedorRepository.Single(predicate);
        }

        public void Create(Proveedor entity)
        {
            var result = _proveedorValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.ProveedorId != default(int))
                _proveedorRepository.Update(entity);
            else
            {
                var exist = _proveedorRepository.Exist(x => x.RazonSocial == entity.RazonSocial);
                if (exist)
                    throw new CustomException("El proveedor que intenta registrar ya existe.");
                _proveedorRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Proveedor, bool>> predicate)
        {
            _proveedorRepository.Delete(predicate);
        }
    }
}
