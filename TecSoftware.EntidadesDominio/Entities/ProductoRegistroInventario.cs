namespace TecSoftware.EntidadesDominio
{
    public class ProductoRegistroInventario
    {
        public int Id { get; set; }
        public int RegistroInventarioId { get; set; }
        public int ProductoOrdenInventarioId { get; set; }
        public decimal Cantidad { get; set; }

        public virtual RegistroInventario RegistroInventario { get; set; }
        public virtual ProductoOrdenInventario ProductoOrdenInventario { get; set; }
    }
}