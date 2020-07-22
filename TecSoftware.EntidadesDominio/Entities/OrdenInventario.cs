using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class OrdenInventario
    {
        public int OrdenInventarioId { get; set; }
        public string NumeroOrden { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public OrdenInventarioStatus EstadoOrden { get; set; }

        public virtual ICollection<ProductoOrdenInventario> ProductoOrdenInventarios { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
