using System.Collections.Generic;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IProveedor<T> where T : class
    {
        List<Proveedor> DetalleItemTemp { get; }

        void Agregar(T entity);
        void CleanProveedor();
    }
}