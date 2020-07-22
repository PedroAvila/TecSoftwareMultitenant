using GlobalTech.TextBoxControl;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class TipoIdentificacion
    {
        public int TipoIdentificacionId { get; set; }
        public string Codigo { get; set; }
        [ComboDisplayMember]
        public string Nombre { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        public virtual ICollection<ComprobantePago> ComprobantePagos { get; set; }
    }
}