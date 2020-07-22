namespace TecSoftware.EntidadesDominio
{
    public class Denominacion
    {
        public int DenominacionId { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public DenominacionStatus Estado { get; set; }
    }
}