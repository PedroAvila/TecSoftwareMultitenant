using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdOrdenVenta
    {
        Task<string> CodigoNumerico();
        Task Create(OrdenVenta entity);
        Task<IEnumerable<UniversalExtend>> SelectOrdenesDeVenta(CriteriaOrdenVenta filter);
        Task<OrdenVenta> Single(Expression<Func<OrdenVenta, bool>> predicate);
    }
}