namespace TecSoftware.EntidadesDominio
{
    public class ProductoColor
    {
        public int ProductoId { get; set; }
        public int ColorId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Colour Colour { get; set; }
    }
}
