namespace TecSoftware.EntidadesDominio
{
    public class ConceptoInventario
    {
        public int ConceptoInventarioId { get; set; }
        public string Nombre { get; set; }
        public OperacionType TipoOperacion { get; set; }
    }
}
