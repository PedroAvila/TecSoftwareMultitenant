using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdNumeradorComprobante
    {
        Task Create(NumeradorComprobante entity);
        Task Delete(Expression<Func<NumeradorComprobante, bool>> predicate);
        Task<bool> Exist(Expression<Func<NumeradorComprobante, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaNumerador(Expression<Func<NumeradorComprobante, UniversalExtend>> source);
        Task<string> NumeroSecuencial(int puntoEmision, int comprobante);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<NumeradorComprobante, bool>> predicate, Expression<Func<NumeradorComprobante, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<NumeradorComprobante, UniversalExtend>> source);
        Task<NumeradorComprobante> Single(Expression<Func<NumeradorComprobante, bool>> predicate);
        Task UpdateNumerador(NumeradorComprobante entity);
    }
}