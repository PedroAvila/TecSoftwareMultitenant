namespace TecSoftware.EntidadesDominio
{
    public class Presentacion
    {
        public int PresentacionId { get; set; }
        public int MedidaId { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public decimal Equivalencia { get; set; }
        public PresentacionStatus Estado { get; set; }

        public Medida Medida { get; set; }
    }
}