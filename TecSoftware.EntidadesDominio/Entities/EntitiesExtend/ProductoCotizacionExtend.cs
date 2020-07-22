namespace TecSoftware.EntidadesDominio
{
    public class ProductoCotizacionExtend
    {
        private Helper _helper = new Helper();
        public int ProductoCotizacionId { get; set; }
        public int SolicitudCotizacionId { get; set; }
        public int ProductoRequerimientoId { get; set; }
        public FormaPagoType FormaPago { get; set; }
        public string NombreFormaPago
        {
            get { return _helper.GetDescription(FormaPago); }
        }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public decimal Cantidad { get; set; }
        public int MedidaId { get; set; }
        public string NombreMedida { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ValorTasaImpuesto { get; set; }
        public decimal ValorIva { get; set; }
        public decimal TotalDescuento { get; set; }
    }
}
