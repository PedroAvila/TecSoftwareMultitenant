using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdPuntoEmision
    {
        Task Create(PuntoEmision entity);
        Task Delete(Expression<Func<PuntoEmision, bool>> predicate);
        Task<bool> Exist(Expression<Func<PuntoEmision, bool>> predicate);
        Task<IEnumerable<PuntoEmision>> Filter(Expression<Func<PuntoEmision, bool>> predicate, List<Expression<Func<PuntoEmision, object>>> includes);
        IEnumerable<PuntoEmision> GetAll();
        Task<IEnumerable<UniversalExtend>> ListaPtoEmision();
        Task<IEnumerable<UniversalExtend>> ListaPtoEmision(int id);
        Task<IEnumerable<UniversalExtend>> ListaPuntoEmision(Expression<Func<PuntoEmision, bool>> predicate, Expression<Func<PuntoEmision, UniversalExtend>> source);
        Task<string> NumeroSerie(int puntoEmision);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<PuntoEmision, bool>> predicate, Expression<Func<PuntoEmision, UniversalExtend>> source);
        Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<PuntoEmision, UniversalExtend>> source);
        Task<PuntoEmision> Single(Expression<Func<PuntoEmision, bool>> predicate);
        Task Update(PuntoEmision entity);
        Task UpdatePuntoEmision(PuntoEmision entity);
    }
}