using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdDenominacion
    {
        private readonly DenominacionRepository _denominacionRepository = new DenominacionRepository();

        public IEnumerable<UniversalExtend> SelectList
            (Expression<Func<Denominacion, bool>> predicate, Expression<Func<Denominacion, UniversalExtend>> source)
        {
            return _denominacionRepository.SelectList(predicate, source);
        }
    }
}
