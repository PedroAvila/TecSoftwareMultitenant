using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdBaseDato : ISdBaseDato
    {
        private readonly BaseDatoRepository _baseDatoRepository = new BaseDatoRepository();

        public async Task Create(BaseDato entity)
        {
            await _baseDatoRepository.Create(entity);
        }

        public async Task<IEnumerable<string>> GetAll(string nameTenan)
        {
            return await _baseDatoRepository.GetAll(nameTenan);
        }
    }
}
