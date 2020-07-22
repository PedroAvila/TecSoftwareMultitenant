using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum IncluyeImpuesto : int
    {
        [Description("SI")]
        Si = 1,
        [Description("NO")]
        No = 2
    }
}
