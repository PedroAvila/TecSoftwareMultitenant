using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdComprobante
    {
        Task AsignarIdentificaciones(Comprobante comprobante, List<TipoIdentificacion> identificaciones);
        Task<IEnumerable<UniversalExtend>> ComprobantePagos();
        Task Create(Comprobante entity);
        Task Delete(Expression<Func<Comprobante, bool>> predicate);
        Task<IEnumerable<UniversalExtend>> ListaComprobantes();
        Task<IEnumerable<UniversalExtend>> ListaComprobantes(Expression<Func<Comprobante, UniversalExtend>> source);
        Task RemoveIdentificaciones(Comprobante comprobante, List<TipoIdentificacion> identificaciones);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Comprobante, bool>> predicate, Expression<Func<Comprobante, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<Comprobante, UniversalExtend>> source);
        Task<Comprobante> Single(Expression<Func<Comprobante, bool>> predicate);
        Task<Comprobante> Single(Expression<Func<Comprobante, bool>> predicate, List<Expression<Func<Comprobante, object>>> includes);
    }
}