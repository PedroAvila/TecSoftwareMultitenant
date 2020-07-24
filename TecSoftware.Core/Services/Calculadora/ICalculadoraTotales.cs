using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ICalculadoraTotales
    {
        decimal? CalcularImporte(decimal? cantidad, ProductoPrecio productoPrecio);
    }
}
