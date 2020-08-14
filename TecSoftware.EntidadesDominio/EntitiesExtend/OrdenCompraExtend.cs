using System;

namespace TecSoftware.EntidadesDominio
{
    public class OrdenCompraExtend
    {
        private Helper _helper = new Helper();

        public int OrdenCompraId { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public FormaPagoType FormaPago { get; set; }
        public string NumeroOrden { get; set; }
        public int ProveedorId { get; set; }
        public string RazonSocial { get; set; }
        public string DireccionEntrega { get; set; }
        public decimal Total { get; set; }
        public string NombreProducto { get; set; }
        public string NombreMedida { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }

        public string NombreFormaPago
        {
            get { return _helper.GetDescription(this.FormaPago); }
        }
    }
}
