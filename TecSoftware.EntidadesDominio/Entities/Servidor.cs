using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Servidor
    {
        public int ServidorId { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<BaseDato> BaseDatos { get; set; }
    }
}
