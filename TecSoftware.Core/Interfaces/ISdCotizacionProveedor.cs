using System.Data;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdCotizacionProveedor
    {
        DataSet CotizacionProveedor();
        Task Create(CotizacionProveedor entity);
    }
}