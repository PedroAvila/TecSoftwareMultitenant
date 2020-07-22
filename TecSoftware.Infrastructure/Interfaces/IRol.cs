using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IRol<T> where T : class
    {
        Task AsignarFunciones(T rol, List<Funcion> funciones);
        Task RemoveFunciones(T rol, List<Funcion> funciones);
    }
}