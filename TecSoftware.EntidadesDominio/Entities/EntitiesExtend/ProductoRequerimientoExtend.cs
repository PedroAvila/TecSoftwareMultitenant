namespace TecSoftware.EntidadesDominio
{
    public class ProductoRequerimientoExtend
    {
        public int ProductoRequerimientoId { get; set; }
        public int RequerimientoCompraId { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int MedidaId { get; set; }
        public string NombreMedida { get; set; }
        public decimal Cantidad { get; set; }
        public int AreaNegocioId { get; set; }
        public string NombreAreaNegocio { get; set; }
    }
}
