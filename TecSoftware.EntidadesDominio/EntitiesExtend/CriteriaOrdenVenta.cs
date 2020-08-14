using System;

namespace TecSoftware.EntidadesDominio
{
    public class CriteriaOrdenVenta
    {
        public int? ClienteId { get; set; }
        public string Codigo { get; set; }
        public DateTime? FechaEmisionDesde { get; set; }
        public DateTime? FechaEmisionHasta { get; set; }
    }
}
