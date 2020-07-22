namespace TecSoftware.EntidadesDominio
{
    public class ProductoPrecioExtend
    {
        private Helper _helper = new Helper();

        public int ProductoPrecioId { get; set; }
        public int ListaPrecioId { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int MedidaId { get; set; }
        public string NombreMedida { get; set; }
        public PrecioType TipoPrecioId { get; set; }
        public string NombreTipoPrecio { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal CantidadMinima { get; set; }
        public decimal CantidadMaxima { get; set; }
        public decimal Utilidad { get; set; }
        public decimal Pvp { get; set; }
        public decimal? ImporteMinimo { get; set; }
        public string DescripcionTypePrecio
        {
            get { return _helper.GetDescription(this.TipoPrecioId); }
        }
    }
}
