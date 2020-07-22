using System;

namespace TecSoftware.EntidadesDominio
{
    public class HistoricoProductoPrecio
    {
        public int Id { get; set; }
        public int ProductoPrecioId { get; set; }
        public decimal CantidadMinima { get; set; }
        public decimal CantidadMaxima { get; set; }
        public int TipoPrecioId { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Utilidad { get; set; }
        public decimal Pvp { get; set; }
        public DateTime FechaUpdate { get; set; }

        public virtual ProductoPrecio ProductoPrecio { get; set; }
    }
}
