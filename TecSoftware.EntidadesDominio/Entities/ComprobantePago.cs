using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class ComprobantePago
    {
        public int ComprobantePagoId { get; set; }
        public string CodigoNumerico { get; set; } //8 dígitos.
        public string NumeroComprobante { get; set; } //15 dígitos
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaEmision { get; set; }
        public int DigitoVerificador { get; set; }
        public int PuntoEmisionId { get; set; }
        public int ComprobanteId { get; set; }
        public int TipoIdentificacionId { get; set; }
        public int FormaPagoId { get; set; }
        public int? EstadoCe { get; set; } //Estado comprobante electrónico.
        public ComprobantePagoStatus Estado { get; set; }
        public decimal Total { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual PuntoEmision PuntoEmision { get; set; }
        public virtual Comprobante Comprobante { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        public virtual FormaPago FormaPago { get; set; }
        public virtual EstadoComprobanteElectronico EstadoComprobanteElectronico { get; set; }

        public virtual ICollection<DetalleComprobantePago> DetalleComprobantePagos { get; set; }
    }
}