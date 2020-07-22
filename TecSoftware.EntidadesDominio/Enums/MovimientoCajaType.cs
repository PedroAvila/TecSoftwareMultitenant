using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum MovimientoCajaType : int
    {
        [Description("INGRESO")]
        Ingreso = 1,
        [Description("DEVOLUCIÓN")]
        Devolucion = 2,
        [Description("GASTO")]
        Gasto = 3
    }
}
