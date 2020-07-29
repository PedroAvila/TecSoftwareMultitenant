namespace TecSoftware.EntidadesDominio
{
    public class ProductoProveedor
    {
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
