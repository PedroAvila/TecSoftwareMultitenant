namespace TecSoftware.EntidadesDominio
{
    public class DetalleOrdenVenta
    {
        //private decimal importe { get; set; }

        public int DetalleOrdenVentaId { get; set; }
        public int OrdenVentaId { get; set; }
        public int ProductoId { get; set; }
        public int PresentacionId { get; set; }
        public int ProductoPrecioId { get; set; }
        public decimal Cantidad { get; set; }
        //public decimal Precio { get; set; }
        public decimal SubTotalIva { get; set; }

        //public decimal Importe => importe = Cantidad * Precio;

        public decimal SubTotalCero { get; set; }
        public decimal SubTotalNoObjetoIva { get; set; }
        public decimal SubTotalExentoIva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal ValorIce { get; set; }
        public decimal ValorIrbpnr { get; set; }
        public decimal ValorIva { get; set; }

        public virtual OrdenVenta OrdenVenta { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Presentacion Presentacion { get; set; }
        public virtual ProductoPrecio ProductoPrecio { get; set; }
    }
}