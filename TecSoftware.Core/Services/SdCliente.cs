using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdCliente
    {
        private readonly ClienteRepository _clienteRepository = new ClienteRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Cliente, UniversalExtend>> source)
        {
            return await _clienteRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<Cliente, bool>> predicate, Expression<Func<Cliente, UniversalExtend>> source)
        {
            return await _clienteRepository.SelectList(predicate, source);
        }

        public async Task<IEnumerable<UniversalExtend>> ListaClienteXCodigo(Criteria filter)
        {
            return await _clienteRepository.ListaClienteXCodigo(filter);
        }

        public async Task<Cliente> Single(Expression<Func<Cliente, bool>> predicate)
        {
            return await _clienteRepository.Single(predicate);
        }

        public async Task Create(Cliente entity)
        {

            if (entity.ClienteId != default(int))
                await _clienteRepository.Update(entity);
            else
            {
                bool exist = await _clienteRepository.Exist(x => x.Numero == entity.Numero);
                if (exist)
                    throw new CustomException("El número de documento que intenta registrar ya existe.");
                await _clienteRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<Cliente, bool>> predicate)
        {
            await _clienteRepository.Delete(predicate);
        }
    }
}
