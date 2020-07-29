using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdRecuento
    {
        Task Create(Recuento entity);
        Task<IEnumerable<CierreCajaExtend>> MostrarCierreCaja(int operacion, int puntoEmision);
        Task<IEnumerable<RecuentoDenominacionExtend>> MostrarRecuentoDenominacion(int operacion);
    }
}