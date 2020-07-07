using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum EstadoDB : int
    {
        [Description("CONECTADO")]
        Conectado = 1,
        [Description("DESCONECTADO")]
        Desconectado = 2
    }
}
