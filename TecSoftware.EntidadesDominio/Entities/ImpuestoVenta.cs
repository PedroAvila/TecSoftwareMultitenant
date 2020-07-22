namespace TecSoftware.EntidadesDominio
{
    public class ImpuestoVenta
    {
        public int ImpuestoVentaId { get; set; }
        public int DetalleComprobantePagoId { get; set; }
        public int TasaImpuestoId { get; set; }

        public virtual DetalleComprobantePago DetaaComprobantePago { get; set; }
        public virtual TasaImpuesto TasaImpuesto { get; set; }
    }
}