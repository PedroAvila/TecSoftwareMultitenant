using System;

namespace TecSoftware.EntidadesDominio
{
    public class OrdenInventarioExtend
    {
        private Helper _helper = new Helper();

        public int OrdenInventarioId { get; set; }
        public string NumeroOrden { get; set; }
        public DateTime FechaEmision { get; set; }
        public OrdenInventarioStatus EstadoOrden { get; set; }

        public string EstadoOrdenDescripcion
        {
            get { return _helper.GetDescription(EstadoOrden); }
        }
    }
}
