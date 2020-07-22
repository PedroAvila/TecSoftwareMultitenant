using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class OrdenCompra
    {
        public int OrdenCompraId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string DireccionEntrega { get; set; } //Lugar de entrega
        public FormaPagoType FormaPago { get; set; }
        public string NumeroOrden { get; set; }
        public OrdenCompraStatus EstadoOrdenCompra { get; set; }
        public int UsuarioId { get; set; }
        public decimal Total { get; set; }

        public virtual Proveedor Proveedor { get; set; }
        public Usuario Usuario { get; set; }
        public virtual ICollection<ProductoOrdenCompra> ProductoOrdenCompras { get; set; }
    }
}
