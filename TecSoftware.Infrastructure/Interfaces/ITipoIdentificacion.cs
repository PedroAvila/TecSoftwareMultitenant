using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface ITipoIdentificacion<T> where T : class
    {
        Task<List<ICollection<T>>> IdentificacionXComprobante(int id);
        Task<IEnumerable<UniversalExtend>> ListaIdentificacionXCodigo();
        Task<IEnumerable<TipoIdentificacionExtend>> ListaVinculacionDatos
            (Expression<Func<T, TipoIdentificacionExtend>> source);
    }
}