namespace TecSoftware.EntidadesDominio
{
    public class ProductoOrdenInventarioExtend
    {
        private readonly Helper _helper = new Helper();

        public int Id { get; set; }
        public int OrdenInventarioId { get; set; }
        public int ConceptoInventarioId { get; set; }
        public string NombreConceptoInventario { get; set; }
        public string NumeroOrden { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int PresentacionId { get; set; }
        public string NombrePresentacion { get; set; }
        public OperacionType TipoOperacion { get; set; }
        public string NombreTipoOperacion
        {
            get { return _helper.GetDescription(TipoOperacion); }
        }
        public int AlmacenId { get; set; }
        public string NombreAlmacen { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
