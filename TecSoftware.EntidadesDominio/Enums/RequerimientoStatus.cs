using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum RequerimientoStatus : int
    {
        [Description("EMITIDO")]
        Emitido = 1,
        [Description("APROBADO")]
        Aprobado = 2,
        [Description("ATENDIDO")]
        Atendido = 3
    }
}
