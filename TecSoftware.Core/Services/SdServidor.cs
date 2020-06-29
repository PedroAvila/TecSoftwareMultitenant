using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdServidor : ISdServidor
    {
        private readonly ServidorRepository _servidorRepository = new ServidorRepository();
        public async Task Create(Servidor entity)
        {
            await _servidorRepository.Create(entity);
        }
    }
}
