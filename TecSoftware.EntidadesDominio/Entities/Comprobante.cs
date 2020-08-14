using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Comprobante
    {
        public int ComprobanteId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public ComprobanteStatus Estado { get; set; }

        //public virtual ICollection<TipoIdentificacion> TipoIdentificaciones { get; set; }
        public virtual ICollection<ComprobantePago> ComprobantePagos { get; set; }
        public virtual ICollection<ComprobanteTipoIdentificacion> ComprobanteTipoIdentificaciones { get; set; }
    }
}