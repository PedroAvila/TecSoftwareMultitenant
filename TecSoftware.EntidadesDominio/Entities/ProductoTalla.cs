namespace TecSoftware.EntidadesDominio
{
    public class ProductoTalla
    {
        public int ProductoId { get; set; }
        public int TallaId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Talla Talla { get; set; }
    }
}
