using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum OperacionType : int
    {
        [Description("ENTRADA")]
        Entrada = 1,
        [Description("SALIDA")]
        Salida = 2
        //[Description("AMBOS")]
        //Ambos = 3
    }
}
