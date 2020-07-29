using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdConceptoInventario
    {
        Task Create(ConceptoInventario entity);
        Task Delete(Expression<Func<ConceptoInventario, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaConceptoInventario(Expression<Func<ConceptoInventario, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<ConceptoInventario, UniversalExtend>> source);
        Task<ConceptoInventario> Single(Expression<Func<ConceptoInventario, bool>> predicate);
    }
}