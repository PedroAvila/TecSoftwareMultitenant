namespace TecSoftware.EntidadesDominio
{
    public class ProductoCotizacionProveedorExtend
    {
        private Helper _helper = new Helper();
        public int ProductoCotizacionProveedorId { get; set; }
        public int CotizacionProveedorId { get; set; }
        public int ProductoCotizacionId { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public int MedidaId { get; set; }
        public string NombreMedida { get; set; }
        public FormaPagoType FormaPago { get; set; }
        public string NombreFormaPago { get; set; }
        public decimal Cantidad { get; set; }

        public string DescripcionFormaPago
        {
            get { return _helper.GetDescription(this.FormaPago); }
        }

        public decimal PrecioCompra { get; set; }
        public decimal TasaImpuesto { get; set; }
        //public decimal SubTotal { get; set; }
        public decimal SubTotal => Cantidad * PrecioCompra;
        public decimal ValorIva => SubTotal * (12M / 100);
    }
}
