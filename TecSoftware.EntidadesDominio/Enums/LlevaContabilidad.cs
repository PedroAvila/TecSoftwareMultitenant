using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum LlevaContabilidad : int
    {
        [Description("SI")]
        No = 0,
        [Description("NO")]
        Si = 1
    }
}
