using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdInquilino : ISdInquilino
    {
        private readonly InquilinoRepository _inquilinoRepository = new InquilinoRepository();
        public async Task Create(Inquilino entity)
        {
            await _inquilinoRepository.Create(entity);
        }
    }
}
