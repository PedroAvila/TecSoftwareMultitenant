namespace TecSoftware.EntidadesDominio
{
    public class ProductoAlmacen
    {
        public int ProductoAlmacenId { get; set; }
        public int AlmacenId { get; set; }
        public int ProductoId { get; set; }
        public int PresentacionId { get; set; }
        public decimal SaldoMinimo { get; set; }
        public decimal? SaldoMaximo { get; set; }
        public decimal Saldo { get; set; }

        public virtual Almacen Almacen { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Presentacion Presentacion { get; set; }
    }
}
