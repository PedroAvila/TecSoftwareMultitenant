using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Impuesto
    {
        public int ImpuestoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public ImpuestoStatus Estado { get; set; }

        public virtual ICollection<TasaImpuesto> TasaImpuestos { get; set; }
    }
}