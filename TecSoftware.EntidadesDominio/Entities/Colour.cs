using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Colour
    {
        public int ColorId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}