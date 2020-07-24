using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public class CalculadoraClasica : CalculadoraBase
    {
        public CalculadoraClasica(Producto producto)
            : base(producto)
        {
        }

        public override decimal? CalcularImporte(decimal? cantidad, ProductoPrecio productoPrecio)
        {
            if (productoPrecio == null || cantidad == null)
            {
                return null;
            }
            return productoPrecio.Pvp * cantidad;
        }
    }
}
