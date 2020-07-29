using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdTipoIdentificacion
    {
        Task Create(TipoIdentificacion entity);
        Task Delete(Expression<Func<TipoIdentificacion, bool>> predicate);
        Task<List<ICollection<TipoIdentificacion>>> IdentificacionXComprobante(int id);
        Task<IEnumerable<UniversalExtend>> ListaIdentificacionXCodigo();
        Task<IEnumerable<TipoIdentificacionExtend>> ListaVinculacionDatos(Expression<Func<TipoIdentificacion, TipoIdentificacionExtend>> source);
        Task<IEnumerable<UniversalExtend>> ListaXCodigo();
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<TipoIdentificacion, UniversalExtend>> source);
        Task<TipoIdentificacion> Single(Expression<Func<TipoIdentificacion, bool>> predicate);
    }
}