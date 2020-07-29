using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdOperacion
    {
        Task Create(Operacion entity);
        Task<bool> Exist(Expression<Func<Operacion, bool>> predicate);
        Task<Operacion> Single(Expression<Func<Operacion, bool>> predicate);
    }
}