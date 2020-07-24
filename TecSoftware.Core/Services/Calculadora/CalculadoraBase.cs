using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public abstract class CalculadoraBase : ICalculadoraTotales
    {
        #region Propiedades
        protected Producto _Producto { get; }
        #endregion

        public CalculadoraBase(Producto producto)
        {
            _Producto = producto;
        }

        public abstract decimal? CalcularImporte(decimal? cantidad, ProductoPrecio productoPrecio);
    }
}
