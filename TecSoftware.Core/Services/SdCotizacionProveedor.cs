using System.Data;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdCotizacionProveedor
    {
        private readonly CotizacionProveedorRepository _cotizacionProveedorRepository = new CotizacionProveedorRepository();

        public void Create(CotizacionProveedor entity)
        {
            entity.NumeroCotizacion = _cotizacionProveedorRepository.GenerarCodigo();
            _cotizacionProveedorRepository.Create(entity);
        }

        public DataSet CotizacionProveedor()
        {
            return _cotizacionProveedorRepository.CotizacionProveedor();
        }
    }
}
