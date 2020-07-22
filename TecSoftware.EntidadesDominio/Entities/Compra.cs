using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Compra
    {
        public int CompraId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime FechaCompra { get; set; }
        public string NumeroFactura { get; set; }
        public int UsuarioId { get; set; }
        public decimal Total { get; set; }
        public CompraStatus EstadoCompra { get; set; }

        public virtual Proveedor Proveedor { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<ProductoCompra> ProductoCompras { get; set; }
    }
}
