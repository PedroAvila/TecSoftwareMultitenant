namespace TecSoftware.EntidadesDominio
{
    public class ProductoCompra
    {
        public int ProductoCompraId { get; set; }
        public int CompraId { get; set; }
        public int ProductoOrdenCompraId { get; set; }
        public int ProductoId { get; set; }
        public int PresentacionId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal SubTotalIva { get; set; }
        public decimal SubTotalCero { get; set; }
        public decimal SubTotalNoObjetoIva { get; set; }
        public decimal SubTotalExentoIva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal ValorIce { get; set; }
        public decimal ValorIrbpnr { get; set; }
        public decimal ValorIva { get; set; }
        public decimal Propina { get; set; }

        public virtual Compra Compra { get; set; }
        public virtual ProductoOrdenCompra ProductoOrdenCompra { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Presentacion Presentacion { get; set; }
    }
}