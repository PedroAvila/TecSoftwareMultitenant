using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Talla
    {
        public int TallaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<ProductoTalla> ProductoTallas { get; set; }
    }
}