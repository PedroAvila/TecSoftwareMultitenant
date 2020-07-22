using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Almacen
    {
        public int AlmacenId { get; set; }
        public int EstablecimientoId { get; set; }
        public string Nombre { get; set; } //Almacen 01, Almacen 02
        public AlmacenStatus Estado { get; set; }

        public virtual Establecimiento Establecimiento { get; set; }
        public virtual ICollection<OperacionMovimiento> OperacionMovimientos { get; set; }
        public virtual ICollection<ProductoAlmacen> ProductoAlmacenes { get; set; }
    }
}
