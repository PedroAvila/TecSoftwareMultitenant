namespace TecSoftware.EntidadesDominio
{
    public class DetalleOrdenVentaExtend
    {
        private decimal importe { get; set; }
        //private decimal descuento;
        public int DetalleOrdenVentaId { get; set; }
        //public string Folio { get; set; }
        public int OrdenVentaId { get; set; }
        public int ProductoPrecioId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int PresentacionId { get; set; }
        public string AbreviacionPresentacion { get; set; }
        public string Medida { get; set; }

        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotalIva { get; set; }
        public decimal Importe => importe = Cantidad * Precio;

        public decimal SubTotalCero { get; set; }
        public decimal SubTotalNoObjetoIva { get; set; }
        public decimal SubTotalExentoIva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDescuento { get; set; }

        public decimal ValorIce { get; set; }
        public decimal ValorIrbpnr { get; set; }
        public decimal ValorIva { get; set; }
        public decimal Iva { get; set; }

        public decimal SumSubTotalIva { get; set; }
        public decimal SumValorIva { get; set; }
        public decimal SumSubtotalIvaCero { get; set; }
        public decimal SumTotal { get; set; }
        public decimal SumaTotalDescuento { get; set; }
    }
}
