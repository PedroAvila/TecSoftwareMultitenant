using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdRequerimientoCompra
    {
        Task Create(RequerimientoCompra entity);
        Task Delete(Expression<Func<RequerimientoCompra, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> SelectRequerimientoCompra(CriteriaDocumento filter);
        Task<RequerimientoCompra> Single(Expression<Func<RequerimientoCompra, bool>> predicate);
    }
}