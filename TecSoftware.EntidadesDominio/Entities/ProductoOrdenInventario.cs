namespace TecSoftware.EntidadesDominio
{
    public class ProductoOrdenInventario
    {
        public int ProductoOrdenInventarioId { get; set; }
        public int OrdenInventarioId { get; set; }
        public int ConceptoInventarioId { get; set; }
        public int ProductoId { get; set; }
        public int PresentacionId { get; set; }
        public OperacionType TipoOperacion { get; set; }
        public int AlmacenId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public virtual OrdenInventario OrdenInventario { get; set; }
        public virtual ConceptoInventario ConceptoInventario { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Presentacion Presentacion { get; set; }
        public virtual Almacen Almacen { get; set; }
    }
}
