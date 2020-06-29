using System.Collections.Generic;
using System.Threading.Tasks;

namespace TecSoftware.Infrastructure
{
    public interface IBaseDato<T> where T : class
    {
        Task<IEnumerable<string>> GetAll(string nameTenan);
    }
}
