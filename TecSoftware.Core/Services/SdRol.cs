using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdRol : ISdRol
    {
        private readonly RolRepository _rolRepository = new RolRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Rol, UniversalExtend>> source)
        {
            return await _rolRepository.SelectList(source);
        }

        public Task<IEnumerable<UniversalExtend>> ListaRoles(Expression<Func<Rol, UniversalExtend>> source)
        {
            var listItem = Task.Run(() => SelectList(source)).Result;
            listItem.ToList().Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<Seleccione>>" });
            return (Task<IEnumerable<UniversalExtend>>)listItem;
        }

        public async Task Create(Rol entity)
        {
            if (entity.RolId != default)
                await _rolRepository.Update(entity);
            else
            {
                var exist = await _rolRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("La categoría que intenta registrar ya existe.");
                await _rolRepository.Create(entity);
            }
        }

        public async Task<Rol> Single(Expression<Func<Rol, bool>> predicate)
        {
            return await _rolRepository.Single(predicate);
        }

        public async Task<Rol> Single(Expression<Func<Rol, bool>> predicate,
            List<Expression<Func<Rol, object>>> includes)
        {
            return await _rolRepository.Single(predicate, includes);
        }

        public async Task<IEnumerable<Rol>> Filter(Expression<Func<Rol, bool>> predicate,
            List<Expression<Func<Rol, object>>> includes)
        {
            return await _rolRepository.Filter(predicate, includes);
        }

        public async Task Delete(Expression<Func<Rol, bool>> predicate)
        {
            await _rolRepository.Delete(predicate);
        }

        public async Task AsignarFunciones(Rol rol, List<Funcion> funciones)
        {
            await _rolRepository.AsignarFunciones(rol, funciones);
        }

        public async Task RemoveFunciones(Rol rol, List<Funcion> funciones)
        {
            await _rolRepository.RemoveFunciones(rol, funciones);
        }


    }
}
