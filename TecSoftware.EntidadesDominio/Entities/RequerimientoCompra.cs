using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class RequerimientoCompra
    {
        public int RequerimientoCompraId { get; set; }
        public string NumeroRequerimiento { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public RequerimientoStatus Estado { get; set; }

        public virtual ICollection<ProductoRequerimiento> ProductoRequerimientos { get; set; }
    }
}