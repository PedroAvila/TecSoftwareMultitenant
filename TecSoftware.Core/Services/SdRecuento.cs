using System.Collections.Generic;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdRecuento
    {
        private readonly RecuentoRepository _recuentoRepository = new RecuentoRepository();

        public void Create(Recuento entity)
        {
            _recuentoRepository.Create(entity);
        }

        public IEnumerable<CierreCajaExtend> MostrarCierreCaja(int operacion, int puntoEmision)
        {
            return _recuentoRepository.MostrarCierreCaja(operacion, puntoEmision);
        }

        public IEnumerable<RecuentoDenominacionExtend> MostrarRecuentoDenominacion(int operacion)
        {
            return _recuentoRepository.MostrarRecuentoDenominacion(operacion);
        }
    }
}
