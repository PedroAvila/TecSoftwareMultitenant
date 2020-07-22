using System.Threading.Tasks;

namespace TecSoftware.Infrastructure
{
    public interface ICotizacionProveedor<T> where T : class
    {
        //DataSet CotizacionProveedor();
        Task<string> GenerarCodigo();
        Task Registrar(T entity);
    }
}