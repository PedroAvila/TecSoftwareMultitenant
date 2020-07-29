using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdColor
    {
        void Agregar(Colour entity);
        void CleanColor();
        Task Create(Colour entity);
        Task Delete(Expression<Func<Colour, bool>> predicate);
        List<Colour> MostrarColors();
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Colour, UniversalExtend>> source);
        Task<Colour> Single(Expression<Func<Colour, bool>> predicate);
    }
}