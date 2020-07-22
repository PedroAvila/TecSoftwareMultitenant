using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum PrecioType : int
    {
        [Description("MINORISTA")]
        Minorista = 1,
        [Description("MAYORISTA")]
        Mayorista = 2
    }
}
