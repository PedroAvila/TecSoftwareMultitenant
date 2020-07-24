using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public class CalculadoraPorRangos : CalculadoraBase
    {
        decimal importe;
        public CalculadoraPorRangos(Producto producto)
            : base(producto)
        {
        }

        public override decimal? CalcularImporte(decimal? cantidad, ProductoPrecio productoPrecio)
        {
            if (productoPrecio == null || cantidad == null)
            {
                return null;
            }
            if (productoPrecio.ImporteMinimo != null)
                importe = productoPrecio.Pvp;
            else
                importe = productoPrecio.Pvp * cantidad.Value;
            return importe;
        }
    }
}
