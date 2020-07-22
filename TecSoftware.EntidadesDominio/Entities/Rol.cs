using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Rol
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Funcion> Funciones { get; set; }
    }
}
