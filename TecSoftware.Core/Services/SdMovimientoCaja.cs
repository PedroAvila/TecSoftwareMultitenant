using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdMovimientoCaja : ISdMovimientoCaja
    {
        private readonly MovimientoCajaRepository _movimientoCajaRepository = new MovimientoCajaRepository();

        /// <summary>
        /// Antes de dar de alta un registro de venta se valida si se aperturo caja cuando se llama 
        /// Al formulario de venta.
        /// </summary>
        /// <param name="entity"></param>
        public async Task Create(MovimientoCaja entity)
        {
            //Informa si esta aperurada la caja
            bool exist = await _movimientoCajaRepository.ExisteMonto(entity.OperacionId);

            if (exist && MovimientoCajaType.Ingreso == entity.TipoMovimiento && entity.ComprobantePagoId == null)
                throw new CustomException("Ya se aperturo caja.");

            if (MovimientoCajaType.Ingreso == entity.TipoMovimiento)
                await _movimientoCajaRepository.Create(entity);
            if (MovimientoCajaType.Gasto == entity.TipoMovimiento)
            {
                var ingreso = await _movimientoCajaRepository.SumIngreso(entity.OperacionId);
                if (entity.MovimientoCajaId != default(int))
                    await _movimientoCajaRepository.Update(entity);
                else
                {
                    if (ingreso >= entity.Egreso)
                        await _movimientoCajaRepository.Create(entity);
                    else
                        throw new CustomException("El egreso supera al total de ingresos");
                }
            }
            if (MovimientoCajaType.Devolucion == entity.TipoMovimiento)
            {
                if (entity.MovimientoCajaId != default(int))
                    await _movimientoCajaRepository.Update(entity);
                else
                    await _movimientoCajaRepository.Create(entity);
            }
        }

        /// <summary>
        /// Obtengo toda la lista de Movimiento de caja por operación abierta y por id de punto de emisión.
        /// </summary>
        /// <param name="puntoEmision">PuntoEmision</param>
        /// <returns></returns>
        public async Task<IEnumerable<MovimientoCaja>> PoolMontos(int puntoEmision)
        {
            return await _movimientoCajaRepository.PoolMontos(puntoEmision);
        }

        /// <summary>
        /// Devuelve el monto inicial por operacion
        /// </summary>
        /// <param name="operacion">Operación</param>
        /// <returns></returns>
        public async Task<decimal> MontoInicial(int operacion)
        {
            return await _movimientoCajaRepository.MontoInicial(operacion);
        }

        public async Task<decimal> MontoInicialXAno(int ano, int puntoEmision)
        {
            return await _movimientoCajaRepository.MontoInicialXAno(ano, puntoEmision);
        }

        public async Task<decimal> SumIngreso(int operacion)
        {
            return await _movimientoCajaRepository.SumIngreso(operacion);
        }

        public async Task<decimal> SumGastos(DateTime fecha, int puntoEmision)
        {
            return await _movimientoCajaRepository.SumGastos(fecha, puntoEmision);
        }

        public async Task<decimal> SumDevolucion(DateTime fecha, int puntoEmision)
        {
            return await _movimientoCajaRepository.SumDevolucion(fecha, puntoEmision);
        }

        //public decimal SumIngresoTotal(DateTime fecha, int puntoEmision)
        //{
        //    return SumIngreso(fecha) + SumDevolucion(fecha, puntoEmision);
        //}

        //public async Task<decimal> Saldo(DateTime fecha, int puntoEmision)
        //{
        //    return await SumIngresoTotal(fecha, puntoEmision) - SumGastos(fecha, puntoEmision);
        //}

        public async Task<IEnumerable<UniversalExtend>> ListarIngreso(int puntoEmision)
        {
            return await _movimientoCajaRepository.ListarIngreso(puntoEmision);
        }

        public async Task<IEnumerable<UniversalExtend>> ListarEgreso(int puntoEmision)
        {
            return await _movimientoCajaRepository.ListarEgreso(puntoEmision);
        }

        public async Task<IEnumerable<UniversalExtend>> ListarDevolucion(int puntoEmision)
        {
            return await _movimientoCajaRepository.ListarDevolucion(puntoEmision);
        }

        public async Task<MovimientoCaja> Single(Expression<Func<MovimientoCaja, bool>> predicate)
        {
            return await _movimientoCajaRepository.Single(predicate);
        }

        public async Task<bool> ExisteMonto(int puntoEmision)
        {
            return await _movimientoCajaRepository.ExisteMonto(puntoEmision);
        }

        /// <summary>
        /// Verifico si el punto de emisión(caja) esta aperturada con un monto inicial.
        /// Verifico en operaciones el puntoEmision y operacionStatus
        /// </summary>
        /// <param name="puntoEmision">PuntoEmision</param>
        /// <returns></returns>
        public async Task<bool> AperturoCaja(int puntoEmision)
        {
            return await _movimientoCajaRepository.AperturoCaja(puntoEmision);
        }
    }
}
