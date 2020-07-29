using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdLaboratorio
    {
        Task Create(Laboratorio entity);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Laboratorio, bool>> predicate, Expression<Func<Laboratorio, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Laboratorio, UniversalExtend>> source);
    }
}