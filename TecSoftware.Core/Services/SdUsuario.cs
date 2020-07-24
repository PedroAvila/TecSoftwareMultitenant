using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdUsuario
    {
        private readonly UsuarioRepository _usuarioRepository = new UsuarioRepository();
        private readonly UsuarioValidator _usuarioValidator = new UsuarioValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Usuario, UniversalExtend>> source)
        {
            return _usuarioRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList
            (Expression<Func<Usuario, bool>> predicate, Expression<Func<Usuario, UniversalExtend>> source)
        {
            return _usuarioRepository.SelectList(predicate, source);
        }

        public Usuario Single(Expression<Func<Usuario, bool>> predicate)
        {
            return _usuarioRepository.Single(predicate);
        }

        public Usuario Single(Expression<Func<Usuario, bool>> predicate,
            List<Expression<Func<Usuario, object>>> includes)
        {
            return _usuarioRepository.Single(predicate, includes);
        }

        public void Create(Usuario entity)
        {
            var result = _usuarioValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.UsuarioId != default(int))
            {
                _usuarioRepository.UpdateUser(entity);
            }
            else
            {
                bool exist = _usuarioRepository.Exist(x => x.Nombre == entity.Nombre);
                if (exist)
                    throw new CustomException("El Nombre que intenta registrar ya existe.");
                bool existUser = _usuarioRepository.Exist(x => x.User == entity.User);
                if (existUser)
                    throw new CustomException("El Usuario que intenta registrar ya existe.");
                var password = Helper.EncodePassword(entity.Password);
                entity.Password = password;
                _usuarioRepository.Create(entity);
            }
        }

        public void UpdatePassword(Usuario entity)
        {
            var password = Helper.EncodePassword(entity.Password);
            entity.Password = password;
            _usuarioRepository.UpdatePassword(entity);
        }

        public void Delete(Expression<Func<Usuario, bool>> predicate)
        {
            _usuarioRepository.Delete(predicate);
        }

        public bool Autentificar(string user, string password)
        {
            string hash = Helper.EncodePassword(password);
            return _usuarioRepository.Autentificar(user, hash);
        }

    }
}
