using System.ComponentModel;

namespace TecSoftware.EntidadesDominio
{
    public enum FormaPagoType : int
    {
        [Description("CONTADO")]
        Contado = 1,
        [Description("CRÉDITO")]
        Credito = 2,
        [Description("PAGO POR ADELANTADO")]
        PagoPorAdelantado = 3
    }
}
