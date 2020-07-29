using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdUbigeo
    {
        Task Create(Ubigeo entity);
        Task Delete(Expression<Func<Ubigeo, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaUbigeo(Expression<Func<Ubigeo, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Ubigeo, UniversalExtend>> source);
        Task<Ubigeo> Single(Expression<Func<Ubigeo, bool>> predicate);
    }
}