using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum CompraStatus : int
    {
        [Description("EMITIDO")]
        Emitido = 1,
        [Description("CANCELADO")]
        Cancelado = 2
    }
}
