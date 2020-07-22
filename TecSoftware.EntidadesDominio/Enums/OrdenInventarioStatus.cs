using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum OrdenInventarioStatus : int
    {
        [Description("EMITIDO")]
        Emitido = 1,
        [Description("APROBADO")]
        Aprobado = 2,
        [Description("ATENDIDO")]
        Atendido = 3,
        [Description("ANULADO")]
        Anulado = 4
    }
}
