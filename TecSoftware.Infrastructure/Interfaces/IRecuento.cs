using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IRecuento<T> where T : class
    {
        Task<IEnumerable<CierreCajaExtend>> MostrarCierreCaja(int operacion, int puntoEmision);
        Task<IEnumerable<RecuentoDenominacionExtend>> MostrarRecuentoDenominacion(int operacion);
    }
}