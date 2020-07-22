using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public int TipoIdentificacionId { get; set; }
        public string Numero { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        public virtual ICollection<ComprobantePago> ComprobantePagos { get; set; }
    }
}
