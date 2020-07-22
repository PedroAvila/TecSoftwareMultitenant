using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class CotizacionProveedor
    {
        public int CotizacionProveedorId { get; set; }
        public string NumeroCotizacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int ProveedorId { get; set; }
        public CotizacionProveedorStatus Estado { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<ProductoCotizacionProveedor> ProductoCotizacionProveedores { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}