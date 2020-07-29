using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdNumeradorOrdenVenta
    {
        Task Create(NumeradorOrdenVenta entity);
        Task Delete(Expression<Func<NumeradorOrdenVenta, bool>> predicate);
        Task<bool> Exist(Expression<Func<NumeradorOrdenVenta, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaNumeradorOrdenVentas(Expression<Func<NumeradorOrdenVenta, UniversalExtend>> source);
        Task<string> NumeroSecuencial(int puntoEmision);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<NumeradorOrdenVenta, bool>> predicate, Expression<Func<NumeradorOrdenVenta, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<NumeradorOrdenVenta, UniversalExtend>> source);
        Task<NumeradorOrdenVenta> Single(Expression<Func<NumeradorOrdenVenta, bool>> predicate);
        Task UpdateNumeradorOrdenVenta(NumeradorOrdenVenta entity);
    }
}