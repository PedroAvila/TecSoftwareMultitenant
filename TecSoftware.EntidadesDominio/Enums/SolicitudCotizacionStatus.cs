using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum SolicitudCotizacionStatus : int
    {
        [Description("EMITIDO")]
        Emitido = 1,
        [Description("APROBADO")]
        Aprobado = 2,
        [Description("ENVIADO")]
        Enviado = 3,
        [Description("ATENDIDO")]
        Atendido = 4
    }
}
