using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum AmbienteType : int
    {
        [Description("PRUEBAS")]
        Pruebas = 1,
        [Description("PRODUCCIÓN")]
        Produccion = 2
    }
}
