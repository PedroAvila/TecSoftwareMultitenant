using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class OrdenVenta
    {
        public int OrdenVentaId { get; set; }
        public string CodigoNumerico { get; set; } //9 dígitos.
        public string NumeroComprobante { get; set; } //15 dígitos
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int PuntoEmisionId { get; set; }
        public decimal Total { get; set; }
        public OrdenVentaStatus Estado { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual PuntoEmision PuntoEmision { get; set; }
        public virtual ICollection<DetalleOrdenVenta> DetalleOrdenVentas { get; set; }
    }
}