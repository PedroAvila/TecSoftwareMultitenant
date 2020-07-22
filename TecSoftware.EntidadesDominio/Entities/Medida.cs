using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Medida
    {
        public int MedidaId { get; set; }
        public string Nombre { get; set; }
        public MedidaStatus Estado { get; set; }

        public virtual ICollection<Presentacion> Presentaciones { get; set; }
    }
}
