using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class RegistroInventario
    {
        public int RegistroInventarioId { get; set; }
        public int OperacionMovimientoId { get; set; }
        public RegistroInventarioType TipoRegistroInventario { get; set; }
        public int AlmacenId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaOperacion { get; set; }

        public virtual OperacionMovimiento OperacionMovimiento { get; set; }
        public virtual Almacen Almacen { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<ProductoRegistroInventario> ProductoRegistroInventarios { get; set; }
    }
}