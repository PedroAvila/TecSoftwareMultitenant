using System;

namespace TecSoftware.EntidadesDominio
{
    public class SolicitudCotizacionExtend
    {
        private Helper _helper = new Helper();

        public int SolicitudCotizacionId { get; set; }
        public string NumeroCotizacion { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public SolicitudCotizacionStatus Estado { get; set; }
        public decimal Total { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string NombreMedida { get; set; }
        public FormaPagoType FormaPago { get; set; }
        public string NombreFormaPago
        {
            get { return _helper.GetDescription(this.FormaPago); }
        }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
