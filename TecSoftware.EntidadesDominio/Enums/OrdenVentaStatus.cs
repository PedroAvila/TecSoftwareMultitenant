using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum OrdenVentaStatus : int
    {
        [Description("EMITIDO")]
        Emitido = 1,
        [Description("APROBADO")]
        Aprobado = 2,
        [Description("ATENDIDO")]
        Atendido = 3
    }
}
