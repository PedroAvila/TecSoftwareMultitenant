namespace TecSoftware.EntidadesDominio
{
    public class ProductoPrecio
    {
        public int ProductoPrecioId { get; set; }
        public int ListaPrecioId { get; set; }
        public int ProductoId { get; set; }
        public int TipoPrecioId { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal CantidadMinima { get; set; }
        public decimal? CantidadMaxima { get; set; }
        public decimal Utilidad { get; set; }
        public decimal Pvp { get; set; }
        public decimal? ImporteMinimo { get; set; }

        public virtual ListaPrecio ListaPrecio { get; set; }
        public virtual Producto Producto { get; set; }
    }
}