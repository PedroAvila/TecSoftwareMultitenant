using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdEmpresa
    {
        Task Create(Empresa entity);
        Task Delete(Expression<Func<Empresa, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaEmpresa(Expression<Func<Empresa, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Empresa, UniversalExtend>> source);
        Task<Empresa> Single(Expression<Func<Empresa, bool>> predicate);
    }
}