using System.Collections.Generic;

namespace TecSoftware.Infrastructure
{
    public interface ITalla<T> where T : class
    {
        List<T> DetalleItemTemp { get; }

        void Agregar(T entity);
        void CleanTalla();
    }
}