using System;

namespace TecSoftware.EntidadesDominio
{
    public class CotizacionProveedorExtend
    {
        private Helper _helper = new Helper();

        public int ProductoCotizacionProveedorId { get; set; }
        public string NumeroCotizacion { get; set; }
        public string NombreProveedor { get; set; }
        public DateTime FechaFin { get; set; }
        public int ProductoId { get; set; }
        public int MedidaId { get; set; }
        public string NombreMedida { get; set; }
        public FormaPagoType FormaPago { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }

        public string FormaPagoDescripcion
        {
            get { return _helper.GetDescription(this.FormaPago); }
        }
    }
}
