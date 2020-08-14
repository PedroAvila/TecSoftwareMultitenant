using System;

namespace TecSoftware.EntidadesDominio
{
    public class CriteriaOrdenInventario
    {
        public bool HasNumberOrder { get; set; }
        public string NumeroOrden { get; set; }
        public bool HasEstadoOrden { get; set; }
        public OrdenInventarioStatus? EstadoOrden { get; set; }
        public bool HasFechaEmisionDesde { get; set; }
        public DateTime? FechaEmisionDesde { get; set; }
        public bool HasFechaEmisionHasta { get; set; }
        public DateTime? FechaEmisionHasta { get; set; }
    }
}
