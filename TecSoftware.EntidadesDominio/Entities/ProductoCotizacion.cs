namespace TecSoftware.EntidadesDominio
{
    public class ProductoCotizacion
    {
        public int ProductoCotizacionId { get; set; }
        public int SolicitudCotizacionId { get; set; }
        public int ProductoRequerimientoId { get; set; }
        public FormaPagoType FormaPago { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public int MedidaId { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ValorTasaImpuesto { get; set; }
        public decimal ValorIva { get; set; }
        public decimal TotalDescuento { get; set; }

        public virtual SolicitudCotizacion SolicitudCotizacion { get; set; }
        public virtual ProductoRequerimiento ProductoRequerimiento { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Medida Medida { get; set; }
    }
}