using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Establecimiento
    {
        public int EstablecimientoId { get; set; }
        public int EmpresaId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular { get; set; }
        public EstablecimientoStatus Estado { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<PuntoEmision> PuntoEmisiones { get; set; }
    }
}
