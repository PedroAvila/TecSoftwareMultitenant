using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum ProductoType : int
    {
        [Description("BIEN")]
        Bien = 1,
        [Description("SERVICIO")]
        Servicio = 2
    }
}
