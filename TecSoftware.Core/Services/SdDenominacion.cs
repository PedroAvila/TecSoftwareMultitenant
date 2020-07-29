using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdDenominacion : ISdDenominacion
    {
        private readonly DenominacionRepository _denominacionRepository = new DenominacionRepository();

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<Denominacion, bool>> predicate, Expression<Func<Denominacion, UniversalExtend>> source)
        {
            return await _denominacionRepository.SelectList(predicate, source);
        }
    }
}
