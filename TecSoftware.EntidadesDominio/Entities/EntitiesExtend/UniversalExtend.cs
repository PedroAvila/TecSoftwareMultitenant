using GlobalTech.TextBoxControl;
using System;

namespace TecSoftware.EntidadesDominio
{
    public class UniversalExtend
    {
        private Helper _helper = new Helper();

        public string Codigo { get; set; } // Código Ubigeo
        public bool Chk { get; set; }
        public bool Permitir { get; set; }
        public int Id { get; set; }
        public int Status { get; set; }
        public int ObjetoId { get; set; }
        public int UsuarioId { get; set; }
        public string Objeto { get; set; }
        public string Usuario { get; set; }
        [ComboDisplayMember]
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string Cedula { get; set; }
        public string Pasaporte { get; set; }
        public decimal PrecioVenta { get; set; }

        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int MedidaId { get; set; }
        public string NombreMedida { get; set; }
        public decimal Cantidad { get; set; }

        public int ProductoPrecioId { get; set; }
        public int PermisoId { get; set; }
        public string Secuencial { get; set; }
        public decimal Pvp { get; set; }

        /// <summary>
        /// Lo utilizo para multiplicar en recuento denominación * cantidad
        /// </summary>
        public decimal Valor { get; set; }
        public string ListaNombre { get; set; }

        //Ordenes de venta
        public string NumeroComprobante { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public OrdenVentaStatus EstadoId { get; set; }
        public OrdenVentaStatus EstadoOrden { get; set; }
        //public OrdenInventarioStatus OrdenInventarioStatus { get; set; }

        public RequerimientoStatus EstadoRequerimiento { get; set; }
        public SolicitudCotizacionStatus EstadoSolicitudCotizacion { get; set; }

        public string EstadoDescripcion
        {
            get { return _helper.GetDescription(this.EstadoId); }
        }

        public string EstadoOrdenDescripcion
        {
            get { return _helper.GetDescription(EstadoOrden); }
        }

        public string EstadoRequerimientoDescripcion
        {

            get { return _helper.GetDescription(EstadoRequerimiento); }
        }

        public string EstadoSolicitudCotizacionDescripcion
        {
            get { return _helper.GetDescription(EstadoSolicitudCotizacion); }
        }
        public decimal Total { get; set; }
    }
}
