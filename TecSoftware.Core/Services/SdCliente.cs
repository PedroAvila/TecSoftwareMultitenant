using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdCliente
    {
        private readonly ClienteRepository _clienteRepository = new ClienteRepository();
        private readonly ClienteValidator _clienteValidator = new ClienteValidator();

        public IEnumerable<UniversalExtend> SelectList(Expression<Func<Cliente, UniversalExtend>> source)
        {
            return _clienteRepository.SelectList(source);
        }

        public IEnumerable<UniversalExtend> SelectList
            (Expression<Func<Cliente, bool>> predicate, Expression<Func<Cliente, UniversalExtend>> source)
        {
            return _clienteRepository.SelectList(predicate, source);
        }

        public IEnumerable<UniversalExtend> ListaClienteXCodigo(Criteria filter)
        {
            return _clienteRepository.ListaClienteXCodigo(filter);
        }

        public Cliente Single(Expression<Func<Cliente, bool>> predicate)
        {
            return _clienteRepository.Single(predicate);
        }

        public void Create(Cliente entity)
        {
            var result = _clienteValidator.Validate(entity);
            if (!result.IsValid)
                throw new CustomException(Validator.GetErrorMessages(result.Errors));
            if (entity.ClienteId != default(int))
                _clienteRepository.Update(entity);
            else
            {
                bool exist = _clienteRepository.Exist(x => x.Numero == entity.Numero);
                if (exist)
                    throw new CustomException("El número de documento que intenta registrar ya existe.");
                _clienteRepository.Create(entity);
            }
        }

        public void Delete(Expression<Func<Cliente, bool>> predicate)
        {
            _clienteRepository.Delete(predicate);
        }
    }
}
