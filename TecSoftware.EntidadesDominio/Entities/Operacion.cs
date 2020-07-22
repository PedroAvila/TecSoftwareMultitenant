using System;
using System.Collections.Generic;

namespace TecSoftware.EntidadesDominio
{
    public class Operacion
    {
        public int OperacionId { get; set; }
        public int PuntoEmisionId { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public OperacionCaja OperacionStatus { get; set; }

        public virtual PuntoEmision PuntoEmision { get; set; }
        public virtual ICollection<MovimientoCaja> MovimientoCajas { get; set; }
        public virtual ICollection<Recuento> Recuentos { get; set; }
    }
}