namespace TecSoftware.EntidadesDominio
{
    public class NumeradorOrdenVenta
    {
        public int Id { get; set; }
        public int PuntoEmisionId { get; set; }
        public string Serie { get; set; } //6
        public string Secuencial { get; set; } //9
        public string Impresora { get; set; }

        public virtual PuntoEmision PuntoEmision { get; set; }
    }
}
