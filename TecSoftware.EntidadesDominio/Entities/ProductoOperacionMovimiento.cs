namespace TecSoftware.EntidadesDominio
{
    public class ProductoOperacionMovimiento
    {
        public int Id { get; set; }
        public int OperacionMovimientoId { get; set; }
        public int ProductoOrdenInventarioId { get; set; }
        public int PresentacionId { get; set; }
        public decimal Cantidad { get; set; }

        public virtual OperacionMovimiento OperacionMovimiento { get; set; }
        public virtual ProductoOrdenInventario ProductoOrdenInventario { get; set; }
        public virtual Presentacion Presentacion { get; set; }
    }
}
