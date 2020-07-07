using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdBaseDato
    {
        Task<IEnumerable<string>> GetAll(string nameTenan);
        Task Create(BaseDato entity);

        Task<BaseDato> Single(
            Expression<Func<BaseDato, bool>> predicate, List<Expression<Func<BaseDato, object>>> includes);

    }
}
