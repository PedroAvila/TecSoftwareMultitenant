using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Core
{
    public interface ISdMovimientoCaja
    {
        Task<bool> AperturoCaja(int puntoEmision);
        Task Create(MovimientoCaja entity);
        Task<bool> ExisteMonto(int puntoEmision);
        Task<IEnumerable<UniversalExtend>> ListarDevolucion(int puntoEmision);
        Task<IEnumerable<UniversalExtend>> ListarEgreso(int puntoEmision);
        Task<IEnumerable<UniversalExtend>> ListarIngreso(int puntoEmision);
        Task<decimal> MontoInicial(int operacion);
        Task<decimal> MontoInicialXAno(int ano, int puntoEmision);
        Task<IEnumerable<MovimientoCaja>> PoolMontos(int puntoEmision);
        Task<MovimientoCaja> Single(Expression<Func<MovimientoCaja, bool>> predicate);
        Task<decimal> SumDevolucion(DateTime fecha, int puntoEmision);
        Task<decimal> SumGastos(DateTime fecha, int puntoEmision);
        Task<decimal> SumIngreso(int operacion);
    }
}