namespace TecSoftware.EntidadesDominio
{
    /// <summary>
    /// Representa una tabla intermedia.
    /// </summary>
    public class ProductoTasaImpuesto
    {
        public int ProductoId { get; set; }
        public int TasaImpuestoId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual TasaImpuesto TasaImpuesto { get; set; }
    }
}
