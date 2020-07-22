using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IPuntoEmision<T> where T : class
    {
        Task<IEnumerable<UniversalExtend>> ListaPtoEmision();
        Task<IEnumerable<UniversalExtend>> ListaPtoEmision(int id);
        Task<string> NumeroSerie(int puntoEmision);
        Task UpdatePuntoEmision(PuntoEmision entity);
    }
}