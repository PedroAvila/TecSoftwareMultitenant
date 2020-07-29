using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdTasaImpuesto
    {
        void Agregar(TasaImpuesto entity);
        void CleanTasaImpuesto();
        Task Create(TasaImpuesto entity);
        Task Delete(Expression<Func<TasaImpuesto, bool>> predicate);
        List<TasaImpuesto> MostrarTasaImpuestos();
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<TasaImpuesto, bool>> predicate, Expression<Func<TasaImpuesto, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<TasaImpuesto, UniversalExtend>> source);
        Task<TasaImpuesto> Single(Expression<Func<TasaImpuesto, bool>> predicate);
    }
}