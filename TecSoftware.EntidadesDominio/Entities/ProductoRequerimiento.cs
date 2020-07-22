namespace TecSoftware.EntidadesDominio
{
    public class ProductoRequerimiento
    {
        public int ProductoRequerimientoId { get; set; }
        public int RequerimientoCompraId { get; set; }
        public int AreaNegocioId { get; set; }
        public int ProductoId { get; set; }
        public int MedidaId { get; set; }
        public decimal Cantidad { get; set; }

        public virtual RequerimientoCompra RequerimientoCompra { get; set; }
        public virtual AreaNegocio AreaNegocio { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Medida Medida { get; set; }
    }
}