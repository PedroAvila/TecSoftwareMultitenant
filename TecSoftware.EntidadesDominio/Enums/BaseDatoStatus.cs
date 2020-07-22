using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum BaseDatoStatus : int
    {
        [Description("CONECTADO")]
        Conectado = 1,
        [Description("DESCONECTADO")]
        Desconectado = 2
    }
}
