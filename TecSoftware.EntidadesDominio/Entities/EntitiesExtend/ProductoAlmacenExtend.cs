namespace TecSoftware.EntidadesDominio
{
    public class ProductoAlmacenExtend
    {
        public int ProductoAlmacenId { get; set; }
        public int AlmacenId { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int PresentacionId { get; set; }
        public string NombrePresentacion { get; set; }
        public decimal SaldoMinimo { get; set; }
        public decimal? SaldoMaximo { get; set; }
        public decimal Saldo { get; set; }
    }
}
