using System;

namespace TecSoftware.EntidadesDominio
{
    public class FacturaExtend
    {
        public string NumeroComprobante { get; set; }
        public DateTime FechaEmision { get; set; }
        public string RazonSocial { get; set; }
        public string Numero { get; set; }
        public string Direccion { get; set; }
        public string NombreComprobante { get; set; }
        public string NombrePuntoEmision { get; set; }
        public string NombreProducto { get; set; }
        public string Abreviacion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal Importe { get; set; }
        public decimal SubTotalIva { get; set; }
        public decimal SubTotalCero { get; set; }
        public decimal SubTotalNoObjetoIva { get; set; }
        public decimal ValorIva { get; set; }
        public decimal Total { get; set; }
    }
}
