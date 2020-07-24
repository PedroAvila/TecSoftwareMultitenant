using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdMovimientoCaja
    {
        private readonly MovimientoCajaRepository _movimientoCajaRepository = new MovimientoCajaRepository();

        /// <summary>
        /// Antes de dar de alta un registro de venta se valida si se aperturo caja cuando se llama 
        /// Al formulario de venta.
        /// </summary>
        /// <param name="entity"></param>
        public void Create(MovimientoCaja entity)
        {
            //Informa si esta aperurada la caja
            bool exist = _movimientoCajaRepository.ExisteMonto(entity.OperacionId);

            if (exist && MovimientoCajaType.Ingreso == entity.TipoMovimiento && entity.ComprobantePagoId == null)
                throw new CustomException("Ya se aperturo caja.");

            if (MovimientoCajaType.Ingreso == entity.TipoMovimiento)
                _movimientoCajaRepository.Create(entity);
            if (MovimientoCajaType.Gasto == entity.TipoMovimiento)
            {
                var ingreso = _movimientoCajaRepository.SumIngreso(entity.OperacionId);
                if (entity.MovimientoCajaId != default(int))
                    _movimientoCajaRepository.Update(entity);
                else
                {
                    if (ingreso >= entity.Egreso)
                        _movimientoCajaRepository.Create(entity);
                    else
                        throw new CustomException("El egreso supera al total de ingresos");
                }
            }
            if (MovimientoCajaType.Devolucion == entity.TipoMovimiento)
            {
                if (entity.MovimientoCajaId != default(int))
                    _movimientoCajaRepository.Update(entity);
                else
                    _movimientoCajaRepository.Create(entity);
            }
        }

        /// <summary>
        /// Obtengo toda la lista de Movimiento de caja por operación abierta y por id de punto de emisión.
        /// </summary>
        /// <param name="puntoEmision">PuntoEmision</param>
        /// <returns></returns>
        public IEnumerable<MovimientoCaja> PoolMontos(int puntoEmision)
        {
            return _movimientoCajaRepository.PoolMontos(puntoEmision);
        }

        /// <summary>
        /// Devuelve el monto inicial por operacion
        /// </summary>
        /// <param name="operacion">Operación</param>
        /// <returns></returns>
        public decimal MontoInicial(int operacion)
        {
            return _movimientoCajaRepository.MontoInicial(operacion);
        }

        public decimal MontoInicialXAno(int ano, int puntoEmision)
        {
            return _movimientoCajaRepository.MontoInicialXAno(ano, puntoEmision);
        }

        public decimal SumIngreso(int operacion)
        {
            return _movimientoCajaRepository.SumIngreso(operacion);
        }

        public decimal SumGastos(DateTime fecha, int puntoEmision)
        {
            return _movimientoCajaRepository.SumGastos(fecha, puntoEmision);
        }

        public decimal SumDevolucion(DateTime fecha, int puntoEmision)
        {
            return _movimientoCajaRepository.SumDevolucion(fecha, puntoEmision);
        }

        public decimal SumIngresoTotal(DateTime fecha, int puntoEmision)
        {
            //return SumIngreso(fecha) + SumDevolucion(fecha, puntoEmision);
            throw new NotImplementedException();
        }

        public decimal Saldo(DateTime fecha, int puntoEmision)
        {
            return SumIngresoTotal(fecha, puntoEmision) - SumGastos(fecha, puntoEmision);
        }

        public IEnumerable<UniversalExtend> ListarIngreso(int puntoEmision)
        {
            return _movimientoCajaRepository.ListarIngreso(puntoEmision);
        }

        public IEnumerable<UniversalExtend> ListarEgreso(int puntoEmision)
        {
            return _movimientoCajaRepository.ListarEgreso(puntoEmision);
        }

        public IEnumerable<UniversalExtend> ListarDevolucion(int puntoEmision)
        {
            return _movimientoCajaRepository.ListarDevolucion(puntoEmision);
        }

        public MovimientoCaja Single(Expression<Func<MovimientoCaja, bool>> predicate)
        {
            return _movimientoCajaRepository.Single(predicate);
        }

        public bool ExisteMonto(int puntoEmision)
        {
            return _movimientoCajaRepository.ExisteMonto(puntoEmision);
        }

        /// <summary>
        /// Verifico si el punto de emisión(caja) esta aperturada con un monto inicial.
        /// Verifico en operaciones el puntoEmision y operacionStatus
        /// </summary>
        /// <param name="puntoEmision">PuntoEmision</param>
        /// <returns></returns>
        public bool AperturoCaja(int puntoEmision)
        {
            return _movimientoCajaRepository.AperturoCaja(puntoEmision);
        }
    }
}
