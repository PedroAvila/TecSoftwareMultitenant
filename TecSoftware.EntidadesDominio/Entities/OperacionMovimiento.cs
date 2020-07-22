using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class OperacionMovimiento
    {
        public int OperacionMovimientoId { get; set; }
        public OperacionStatus EstadoOperacion { get; set; }
        public int AlmacenId { get; set; }
        public DateTime Fecha { get; set; }
        public OperacionType TipoOperacion { get; set; }
        public string Referencia { get; set; }

        public virtual Almacen Almacen { get; set; }
        public virtual ICollection<ProductoOperacionMovimiento> ProductoOperacionMovimientos { get; set; }
        public virtual ICollection<RegistroInventario> RegistroInventarios { get; set; }
    }
}
