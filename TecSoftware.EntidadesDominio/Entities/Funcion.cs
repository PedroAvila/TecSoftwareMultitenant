using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Funcion
    {
        public int FuncionId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Rol> Roles { get; set; }
    }
}
