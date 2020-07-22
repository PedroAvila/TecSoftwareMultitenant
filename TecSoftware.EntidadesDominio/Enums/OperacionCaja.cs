using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum OperacionCaja : int
    {
        [Description("ABRIR")]
        Abrir = 1,
        [Description("CERRAR")]
        Cerrar = 2
    }
}
