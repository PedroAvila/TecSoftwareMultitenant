namespace TecSoftware.EntidadesDominio
{
    public class Moneda
    {
        public int MonedaId { get; set; }
        public string Nombre { get; set; }
        public MonedaStatus Estado { get; set; }
    }
}
