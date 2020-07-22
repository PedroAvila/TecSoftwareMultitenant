using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum OrdenCompraStatus : int
    {
        [Description("EMITIDO")]
        Emitido = 1,
        [Description("APROBADO")]
        Aprobado = 2,
        [Description("ENVIADO")]
        Enviado = 3,
        [Description("ATENDIDO")]
        Atendido = 4
    }
}
