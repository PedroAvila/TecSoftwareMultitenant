using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdAreaNegocio
    {
        Task Create(AreaNegocio entity);
        Task Delete(Expression<Func<AreaNegocio, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaAreaNegocio(Expression<Func<AreaNegocio, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<AreaNegocio, UniversalExtend>> source);
        Task<AreaNegocio> Single(Expression<Func<AreaNegocio, bool>> predicate);
    }
}