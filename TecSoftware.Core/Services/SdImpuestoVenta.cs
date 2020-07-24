using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdImpuestoVenta
    {
        private readonly ImpuestoVentaRepository _impuestoVentaRepository = new ImpuestoVentaRepository();

        public void Create(ImpuestoVenta entity)
        {
            _impuestoVentaRepository.Create(entity);
        }
    }
}
