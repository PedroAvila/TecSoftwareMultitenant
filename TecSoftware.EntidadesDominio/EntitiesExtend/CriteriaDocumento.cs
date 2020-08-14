using System;

namespace TecSoftware.EntidadesDominio
{
    public class CriteriaDocumento
    {
        public bool HasNumber { get; set; }
        public string Numero { get; set; }
        public bool HasEstado { get; set; }
        public int? Estado { get; set; }
        public bool HasFechaDesde { get; set; }
        public DateTime? FechaDesde { get; set; }
        public bool HasFechaHasta { get; set; }
        public DateTime? FechaHasta { get; set; }
    }
}
