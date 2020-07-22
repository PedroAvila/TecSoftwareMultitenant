using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class PuntoEmision
    {
        public int PuntoEmisionId { get; set; }
        public int EstablecimientoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public PuntoEmisionStatus Estado { get; set; }

        public virtual Establecimiento Establecimiento { get; set; }
        public virtual ICollection<ComprobantePago> ComprobantePagos { get; set; }
    }
}