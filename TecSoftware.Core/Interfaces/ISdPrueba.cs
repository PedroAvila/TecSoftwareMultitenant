using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdPrueba
    {
        Task Create(Prueba entity);
    }
}
