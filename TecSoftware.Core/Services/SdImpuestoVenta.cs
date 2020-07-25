using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdImpuestoVenta
    {
        private readonly ImpuestoVentaRepository _impuestoVentaRepository = new ImpuestoVentaRepository();

        public async Task Create(ImpuestoVenta entity)
        {
            await _impuestoVentaRepository.Create(entity);
        }
    }
}
