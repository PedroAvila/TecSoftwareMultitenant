namespace TecSoftware.EntidadesDominio
{
    public class NumeradorComprobante
    {
        public int Id { get; set; }
        public int PuntoEmisionId { get; set; }
        public int ComprobanteId { get; set; }
        public string Serie { get; set; } //6 dígitos
        public string Secuencial { get; set; } //9 dígitos
        public string Impresora { get; set; }

        public virtual PuntoEmision PuntoEmision { get; set; }
        public virtual Comprobante Comprobante { get; set; }
    }
}
