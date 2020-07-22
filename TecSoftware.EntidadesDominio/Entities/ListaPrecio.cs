using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class ListaPrecio
    {
        public int ListaPrecioId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public PrecioStatus Estado { get; set; }

        public virtual ICollection<ProductoPrecio> ProductoPrecios { get; set; }
    }
}