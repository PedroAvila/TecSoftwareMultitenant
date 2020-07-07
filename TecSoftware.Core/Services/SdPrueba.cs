using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdPrueba : ISdPrueba
    {
        private readonly PruebaRepository _pruebaRepository = new PruebaRepository();
        public async Task Create(Prueba entity)
        {
            await _pruebaRepository.Create(entity);
        }
    }
}
