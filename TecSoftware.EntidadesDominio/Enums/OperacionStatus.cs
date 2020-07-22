using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum OperacionStatus : int
    {
        [Description("PREPARAR")]
        Preparar = 1,
        [Description("ATENDER")]
        Atender = 2
    }
}
