using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum EstadoInquilino : int
    {
        [Description("ACTIVO")]
        Activo = 1,
        [Description("INACTIVO")]
        Inactivo = 2
    }
}
