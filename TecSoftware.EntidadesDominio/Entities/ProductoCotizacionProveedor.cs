namespace TecSoftware.EntidadesDominio
{
    public class ProductoCotizacionProveedor
    {
        public int ProductoCotizacionProveedorId { get; set; }
        public int CotizacionProveedorId { get; set; }
        public int ProductoCotizacionId { get; set; }
        public FormaPagoType FormaPago { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public int MedidaId { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal TasaImpuesto { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ValorIva { get; set; }


        public virtual CotizacionProveedor CotizacionProveedor { get; set; }
        public virtual ProductoCotizacion ProductoCotizacion { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Medida Medida { get; set; }
    }
}