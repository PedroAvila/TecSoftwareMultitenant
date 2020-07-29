using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdTalla
    {
        void Agregar(Talla entity);
        void CleanTalla();
        Task Create(Talla entity);
        Task Delete(Expression<Func<Talla, bool>> predicate);
        List<Talla> MostrarTallas();
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Talla, UniversalExtend>> source);
        Task<Talla> Single(Expression<Func<Talla, bool>> predicate);
    }
}