using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdBaseDato
    {
        Task<IEnumerable<string>> GetAll(string nameTenan);
        Task Create(BaseDato entity);

    }
}
