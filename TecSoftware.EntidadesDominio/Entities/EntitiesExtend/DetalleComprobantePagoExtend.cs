namespace TecSoftware.EntidadesDominio
{
    public class DetalleComprobantePagoExtend
    {
        private decimal importe { get; set; }
        public int DetalleComprobantePagoId { get; set; }
        public int ComprobantePagoId { get; set; }
        public int DetalleOrdenVentaId { get; set; }
        public int ProductoId { get; set; }
        public int PresentacionId { get; set; }
        public string AbreviacionPresentacion { get; set; }
        public int ProductoPrecioId { get; set; }
        public string Medida { get; set; }
        public string Descripcion { get; set; }
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
        public decimal Propina { get; set; }

        public decimal SumSubTotalIva { get; set; }
        public decimal SumValorIva { get; set; }
        public decimal SumSubtotalIvaCero { get; set; }
        public decimal SumTotal { get; set; }
    }
}
