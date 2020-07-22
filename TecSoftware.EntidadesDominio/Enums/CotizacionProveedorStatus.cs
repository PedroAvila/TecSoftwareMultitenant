using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum CotizacionProveedorStatus : int
    {
        [Description("ENVIADO")]
        Enviado = 1,
        [Description("RECIBIDO")]
        Recibido = 2,
        [Description("REVISADO")]
        Revisado = 3
    }
}
