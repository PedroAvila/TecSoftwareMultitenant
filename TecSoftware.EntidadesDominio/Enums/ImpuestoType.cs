using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum ImpuestoType : int
    {
        [Description("CON IMPUESTO")]
        ConImpuesto = 1,
        [Description("SIN IMPUESTO")]
        SinImpuesto = 2
    }
}
