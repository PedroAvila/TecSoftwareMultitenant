namespace TecSoftware.EntidadesDominio
{
    public class ComprobanteTipoIdentificacion
    {
        public int ComprobanteId { get; set; }
        public int TipoIdentificacionId { get; set; }

        public virtual Comprobante Comprobante { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
    }
}
