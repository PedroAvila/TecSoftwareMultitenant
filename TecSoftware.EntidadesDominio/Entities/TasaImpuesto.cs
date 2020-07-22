using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class TasaImpuesto
    {
        public int TasaImpuestoId { get; set; }
        public int ImpuestoId { get; set; }
        public string Codigo { get; set; } //tamaño 1 a 4 dependiendo el impuesto.
        public string Nombre { get; set; }
        public string Concepto { get; set; }
        public decimal? Tasa { get; set; }
        public TasaImpuestoStatus Estado { get; set; }

        public virtual Impuesto Impuesto { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<ImpuestoVenta> ImpuestoVentas { get; set; }
    }
}
