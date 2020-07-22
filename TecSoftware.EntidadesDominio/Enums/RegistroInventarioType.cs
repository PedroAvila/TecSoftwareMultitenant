using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum RegistroInventarioType : int
    {
        [Description("ENTRADA")]
        Entrada = 1,
        [Description("SALIDA")]
        Salida = 2
    }
}
