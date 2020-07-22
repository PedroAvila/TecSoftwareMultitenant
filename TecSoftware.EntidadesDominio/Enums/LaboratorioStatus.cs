using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum LaboratorioStatus : int
    {
        [Description("ACTIVO")]
        Activo = 1,

        [Description("INACTIVO")]
        Inactivo = 0
    }
}
