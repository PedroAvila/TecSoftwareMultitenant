using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdRecuento : ISdRecuento
    {
        private readonly RecuentoRepository _recuentoRepository = new RecuentoRepository();

        public async Task Create(Recuento entity)
        {
            await _recuentoRepository.Create(entity);
        }

        public async Task<IEnumerable<CierreCajaExtend>> MostrarCierreCaja(int operacion, int puntoEmision)
        {
            return await _recuentoRepository.MostrarCierreCaja(operacion, puntoEmision);
        }

        public async Task<IEnumerable<RecuentoDenominacionExtend>> MostrarRecuentoDenominacion(int operacion)
        {
            return await _recuentoRepository.MostrarRecuentoDenominacion(operacion);
        }
    }
}
