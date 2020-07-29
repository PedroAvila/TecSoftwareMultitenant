using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdUsuario : ISdUsuario
    {
        private readonly UsuarioRepository _usuarioRepository = new UsuarioRepository();


        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Usuario, UniversalExtend>> source)
        {
            return await _usuarioRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<Usuario, bool>> predicate, Expression<Func<Usuario, UniversalExtend>> source)
        {
            return await _usuarioRepository.SelectList(predicate, source);
        }

        public async Task<Usuario> Single(Expression<Func<Usuario, bool>> predicate)
        {
            return await _usuarioRepository.Single(predicate);
        }

        public async Task<Usuario> Single(Expression<Func<Usuario, bool>> predicate,
            List<Expression<Func<Usuario, object>>> includes)
        {
            return await _usuarioRepository.Single(predicate, includes);
        }

        public async Task Create(Usuario entity)
        {
            if (entity.UsuarioId != default(int))
            {
                await _usuarioRepository.UpdateUser(entity);
            }
            else
            {
                bool exist = await _usuarioRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Nombre que intenta registrar ya existe.");
                bool existUser = await _usuarioRepository.Exist(x => x.User == entity.User);
                if (existUser)
                    throw new CustomException("El Usuario que intenta registrar ya existe.");
                var password = Helper.EncodePassword(entity.Password);
                entity.Password = password;
                await _usuarioRepository.Create(entity);
            }
        }

        public async Task UpdatePassword(Usuario entity)
        {
            var password = Helper.EncodePassword(entity.Password);
            entity.Password = password;
            await _usuarioRepository.UpdatePassword(entity);
        }

        public async Task Delete(Expression<Func<Usuario, bool>> predicate)
        {
            await _usuarioRepository.Delete(predicate);
        }

        public async Task<bool> Autentificar(Usuario entity)
        {
            string hash = Helper.EncodePassword(entity.Password);
            entity.Password = hash;
            return await _usuarioRepository.Autentificar(entity);
        }
    }
}
