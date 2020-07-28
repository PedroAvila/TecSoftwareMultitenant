using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProveedor
    {
        private readonly ProveedorRepository _proveedorRepository = new ProveedorRepository();

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

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Proveedor, UniversalExtend>> source)
        {
            return await _proveedorRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Proveedor, bool>> predicate,
            Expression<Func<Proveedor, UniversalExtend>> source)
        {
            return await _proveedorRepository.SelectList(predicate, source);
        }

        public async Task<Proveedor> Single(Expression<Func<Proveedor, bool>> predicate)
        {
            return await _proveedorRepository.Single(predicate);
        }

        public async Task Create(Proveedor entity)
        {
            if (entity.ProveedorId != default(int))
                await _proveedorRepository.Update(entity);
            else
            {
                var exist = await _proveedorRepository.Exist(x => x.RazonSocial == entity.RazonSocial);
                if (exist)
                    throw new CustomException("El proveedor que intenta registrar ya existe.");
                await _proveedorRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Proveedor, bool>> predicate)
        {
            await _proveedorRepository.Delete(predicate);
        }
    }
}
