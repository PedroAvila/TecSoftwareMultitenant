using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular { get; set; }
        public string Representante { get; set; }
        public string Email { get; set; }
        public string ClaveEmail { get; set; }
        public LlevaContabilidad ObligadoContabilidad { get; set; }
        public int Emision { get; set; }
        public AmbienteType Ambiente { get; set; }
        public byte[] LogoEmisor { get; set; }

        public virtual ICollection<Establecimiento> Establecimientos { get; set; }
    }
}