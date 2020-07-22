namespace TecSoftware.EntidadesDominio
{
    public class ProductoOrdenCompra
    {
        //private decimal importe { get; set; }
        public int ProductoOrdenCompraId { get; set; }
        public int OrdenCompraId { get; set; }
        public int ProductoCotizacionProveedorId { get; set; }
        public ImpuestoType Impuesto { get; set; }
        public int ProductoId { get; set; }
        public int MedidaId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotalIva { get; set; }
        public decimal SubTotalCero { get; set; }
        public decimal SubTotalNoObjetoIva { get; set; }
        public decimal SubTotalExcentoIva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal ValorIva { get; set; }

        //public decimal Importe => importe = Cantidad * PrecioUnitario;

        public virtual OrdenCompra OrdenCompra { get; set; }
        public virtual ProductoCotizacionProveedor ProductoCotizacionProveedor { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Medida Medida { get; set; }
    }
}