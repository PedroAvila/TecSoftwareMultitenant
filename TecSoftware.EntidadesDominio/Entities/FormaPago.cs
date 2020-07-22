using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class FormaPago
    {
        public int FormaPagoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ComprobantePago> ComprobantePagos { get; set; }
    }
}