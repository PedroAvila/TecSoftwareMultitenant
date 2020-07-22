using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum AreaNegocioStatus : int
    {
        [Description("ACTIVO")]
        Activo = 1,

        [Description("INACTIVO")]
        Inactivo = 0
    }
}
