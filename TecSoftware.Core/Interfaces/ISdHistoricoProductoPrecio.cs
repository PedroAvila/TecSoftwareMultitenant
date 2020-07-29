using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdHistoricoProductoPrecio
    {
        Task Create(HistoricoProductoPrecio entity);
    }
}