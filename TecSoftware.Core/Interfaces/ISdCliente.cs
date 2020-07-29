using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdCliente
    {
        Task Create(Cliente entity);
        Task Delete(Expression<Func<Cliente, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaClienteXCodigo(Criteria filter);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Cliente, bool>> predicate, Expression<Func<Cliente, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Cliente, UniversalExtend>> source);
        Task<Cliente> Single(Expression<Func<Cliente, bool>> predicate);
    }
}