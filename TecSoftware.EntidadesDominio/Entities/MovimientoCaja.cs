using System;

namespace TecSoftware.EntidadesDominio
{
    public class MovimientoCaja
    {
        public int MovimientoCajaId { get; set; }
        public int OperacionId { get; set; }
        public int? ComprobantePagoId { get; set; }
        public int UsuarioId { get; set; }
        public MovimientoCajaType TipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal MontoInicial { get; set; }
        public decimal Ingreso { get; set; }
        public decimal Egreso { get; set; }
        public decimal Saldo { get; set; }

        public virtual Operacion Operacion { get; set; }
        public virtual ComprobantePago ComprobantePago { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
