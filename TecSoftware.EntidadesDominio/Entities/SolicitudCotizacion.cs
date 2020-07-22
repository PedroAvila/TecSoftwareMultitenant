using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class SolicitudCotizacion
    {
        public int SolicitudCotizacionId { get; set; }
        public string NumeroCotizacion { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int ProveedorId { get; set; }
        public SolicitudCotizacionStatus Estado { get; set; }
        public decimal Total { get; set; }

        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<ProductoCotizacion> ProductoCotizaciones { get; set; }
    }
}