using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdMarca
    {
        Task Create(Marca entity);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Marca, bool>> predicate, Expression<Func<Marca, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Marca, UniversalExtend>> source);
    }
}