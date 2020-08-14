namespace TecSoftware.EntidadesDominio
{
    public class ProductoOrdenInventarioDto
    {
        public int ProductoOrdenInventarioId { get; set; }
        public int OrdenInventarioId { get; set; }
        public int ConceptoInventarioId { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int PresentacionId { get; set; }
        public OperacionType TipoOperacion { get; set; }
        public int AlmacenId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
