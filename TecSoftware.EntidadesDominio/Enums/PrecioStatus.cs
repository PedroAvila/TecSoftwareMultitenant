using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum PrecioStatus : int
    {
        [Description("VIGENTE")]
        Vigente = 1,
        [Description("CADUCO")]
        Caduco = 2
    }
}
