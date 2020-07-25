using System.Data;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdCotizacionProveedor
    {
        private readonly CotizacionProveedorRepository _cotizacionProveedorRepository = new CotizacionProveedorRepository();

        public async Task Create(CotizacionProveedor entity)
        {
            entity.NumeroCotizacion = await _cotizacionProveedorRepository.GenerarCodigo();
            await _cotizacionProveedorRepository.Create(entity);
        }

        public DataSet CotizacionProveedor()
        {
            return _cotizacionProveedorRepository.CotizacionProveedor();
        }
    }
}
