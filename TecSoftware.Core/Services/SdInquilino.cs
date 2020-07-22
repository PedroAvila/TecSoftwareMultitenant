using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdInquilino : ISdInquilino
    {
        private readonly InquilinoRepository _inquilinoRepository = new InquilinoRepository();

        public Task<bool> Exist(Expression<Func<Inquilino, bool>> predicate)
        {
            return _inquilinoRepository.Exist(predicate);
        }

        public Task<Inquilino> Single(Expression<Func<Inquilino, bool>> predicate,
            List<Expression<Func<Inquilino, object>>> includes)
        {
            return _inquilinoRepository.Single(predicate, includes);
        }

        public async Task Create(Inquilino entity)
        {
            await _inquilinoRepository.Create(entity);
        }


    }
}
