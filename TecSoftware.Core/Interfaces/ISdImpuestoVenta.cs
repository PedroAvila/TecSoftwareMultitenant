using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdImpuestoVenta
    {
        Task Create(ImpuestoVenta entity);
    }
}