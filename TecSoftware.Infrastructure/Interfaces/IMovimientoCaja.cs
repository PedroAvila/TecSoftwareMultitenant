using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public interface IMovimientoCaja<T> where T : class
    {
        Task<bool> AperturoCaja(int puntoEmision);
        Task<MovimientoCaja> Buscar(DateTime fecha, int puntoEmision, MovimientoCajaType movimientoType, int id);
        Task<bool> ExisteMonto(int operacion);
        Task<IEnumerable<UniversalExtend>> ListarDevolucion(int puntoEmision);
        Task<IEnumerable<UniversalExtend>> ListarEgreso(int puntoEmision);
        Task<IEnumerable<UniversalExtend>> ListarIngreso(int puntoEmision);
        Task<decimal> MontoInicial(int operacion);
        Task<decimal> MontoInicialXAno(int ano, int puntoEmision);
        Task<IEnumerable<MovimientoCaja>> PoolMontos(int puntoEmision);
        Task<decimal> SumDevolucion(DateTime fecha, int puntoEmision);
        Task<decimal> SumGastos(DateTime fecha, int puntoEmision);
        Task<decimal> SumIngreso(int operacion);
    }
}