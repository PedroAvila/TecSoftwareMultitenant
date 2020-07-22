using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class MovimientoCajaRepository : BaseRepository<MovimientoCaja>, IMovimientoCaja<MovimientoCaja>
    {
        /// <summary>
        /// OperacionStatus es de tipo de dato OperacionCaja(enum)
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public async Task<decimal> MontoInicial(int operacion)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var maxMontoInicial = from mc in context.MovimientoCajas
                                          //where DbFunctions.TruncateTime(m.Fecha) == DbFunctions.TruncateTime(fecha)
                                          //&& m.OperacionId == operacion
                                      join o in context.Operaciones on mc.OperacionId equals o.OperacionId
                                      where o.OperacionStatus == OperacionCaja.Abrir && mc.MontoInicial > 0
                                      && mc.OperacionId == operacion
                                      select mc.MontoInicial;

                return await maxMontoInicial.FirstOrDefaultAsync();
            }
        }

        public async Task<decimal> MontoInicialXAno(int ano, int puntoEmision)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var maxMontoInicial = from m in context.MovimientoCajas
                                      where m.Fecha.Year == ano
                                      //&& m.PuntoEmisionId == puntoEmision
                                      select m.MontoInicial;

                return await maxMontoInicial.FirstOrDefaultAsync();
            }
        }

        /// <summary>
        /// Verifica si exsite un monto inicial para ingresar monto por única vez.
        /// </summary>
        /// <param name="operacion">OperacionId</param>
        /// <returns></returns>
        //public bool ExisteMonto(DateTime fecha, int operacion)
        public async Task<bool> ExisteMonto(int operacion)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await (from mc in context.MovimientoCajas
                                    join o in context.Operaciones on mc.OperacionId equals o.OperacionId
                                    where o.OperacionStatus == OperacionCaja.Abrir && mc.MontoInicial > 0
                                    && mc.OperacionId == operacion
                                    select mc.MontoInicial).AnyAsync();
                return result;
            }
        }

        /// <summary>
        /// Verificar si es necesario punto de emision
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public async Task<decimal> SumIngreso(int operacion)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await (from mc in context.MovimientoCajas
                                        //where DbFunctions.TruncateTime(m.Fecha) == DbFunctions.TruncateTime(fecha)
                                        //&& m.TipoMovimiento == MovimientoCajaType.Ingreso
                                    join o in context.Operaciones on mc.OperacionId equals o.OperacionId
                                    where o.OperacionStatus == OperacionCaja.Abrir && o.OperacionId == operacion
                                    select mc.Ingreso).SumAsync();

                return result;
            }
        }

        public async Task<decimal> SumGastos(DateTime fecha, int puntoEmision)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = from m in context.MovimientoCajas
                             where m.Fecha.Date == fecha.Date
                             //&& m.PuntoEmisionId == puntoEmision && m.TipoMovimiento == MovimientoCajaType.Gasto
                             select m.Egreso;
                var salida = await result.AnyAsync();
                if (!salida)
                    return Convert.ToDecimal(0);
                else
                    return await result.SumAsync();
            }
        }

        public async Task<decimal> SumDevolucion(DateTime fecha, int puntoEmision)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = from m in context.MovimientoCajas
                             where m.Fecha.Date == fecha.Date
                             //&& m.PuntoEmisionId == puntoEmision && m.TipoMovimiento == MovimientoCajaType.Devolucion
                             select m.Ingreso;
                var salida = await result.AnyAsync();
                if (!salida)
                    return Convert.ToDecimal(0);
                else
                    return await result.SumAsync();
            }
        }

        /// <summary>
        /// Obtengo toda la lista de Movimiento de caja por operación abierta y por id de operación.
        /// </summary>
        /// <param name="operacion">Operación</param>
        /// <returns></returns>
        public async Task<IEnumerable<MovimientoCaja>> PoolMontos(int puntoEmision)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await (from mc in context.MovimientoCajas
                                        //where DbFunctions.TruncateTime(m.Fecha) == DbFunctions.TruncateTime(fecha)
                                    join o in context.Operaciones on mc.OperacionId equals o.OperacionId
                                    where o.OperacionStatus == OperacionCaja.Abrir
                                    && o.PuntoEmisionId == puntoEmision
                                    select mc).ToListAsync();
                return result;
            }
        }

        public async Task<MovimientoCaja> Buscar(DateTime fecha, int puntoEmision, MovimientoCajaType movimientoType, int id)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await (from m in context.MovimientoCajas
                                    where m.Fecha.Date == fecha.Date
                                          //&& m.PuntoEmisionId == puntoEmision && m.TipoMovimiento == movimientoType
                                          && m.MovimientoCajaId == id
                                    select m).FirstOrDefaultAsync();
                return result;
            }
        }

        public async Task<IEnumerable<UniversalExtend>> ListarIngreso(int puntoEmision)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = from m in context.MovimientoCajas
                             join o in context.Operaciones on m.OperacionId equals o.OperacionId
                             join cp in context.ComprobantePagos on m.ComprobantePagoId equals cp.ComprobantePagoId
                             join c in context.Comprobantes on cp.ComprobanteId equals c.ComprobanteId
                             where m.TipoMovimiento == MovimientoCajaType.Ingreso && o.PuntoEmisionId == puntoEmision
                             && o.OperacionStatus == OperacionCaja.Abrir
                             select new UniversalExtend()
                             {
                                 Descripcion = string.Concat(c.Nombre, " # ", cp.NumeroComprobante),
                                 PrecioVenta = m.Ingreso
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<IEnumerable<UniversalExtend>> ListarEgreso(int puntoEmision)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = from m in context.MovimientoCajas
                             join o in context.Operaciones on m.OperacionId equals o.OperacionId
                             //where DbFunctions.TruncateTime(m.Fecha) == DbFunctions.TruncateTime(fecha)
                             where o.PuntoEmisionId == puntoEmision && m.TipoMovimiento == MovimientoCajaType.Gasto
                             && o.OperacionStatus == OperacionCaja.Abrir
                             select new UniversalExtend()
                             {
                                 Id = m.MovimientoCajaId,
                                 Descripcion = m.Concepto,
                                 PrecioVenta = m.Egreso
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<IEnumerable<UniversalExtend>> ListarDevolucion(int puntoEmision)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = from m in context.MovimientoCajas
                             join o in context.Operaciones on m.OperacionId equals o.OperacionId
                             //where DbFunctions.TruncateTime(m.Fecha) == DbFunctions.TruncateTime(fecha)
                             where o.PuntoEmisionId == puntoEmision && m.TipoMovimiento == MovimientoCajaType.Devolucion
                             && o.OperacionStatus == OperacionCaja.Abrir
                             select new UniversalExtend()
                             {
                                 Id = m.MovimientoCajaId,
                                 Descripcion = m.Concepto,
                                 PrecioVenta = m.Ingreso
                             };
                return await result.ToListAsync();
            }
        }

        /// <summary>
        /// Verifico si el punto de emisión(caja) esta aperturada con un monto inicial.
        /// Verifico en operaciones el puntoEmision y operacionStatus
        /// </summary>
        /// <param name="puntoEmision">PuntoEmision</param>
        /// <returns></returns>
        public async Task<bool> AperturoCaja(int puntoEmision)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await (from m in context.MovimientoCajas
                                    join o in context.Operaciones on m.OperacionId equals o.OperacionId
                                    where o.PuntoEmisionId == puntoEmision && o.OperacionStatus == OperacionCaja.Abrir
                                    && m.MontoInicial > 0
                                    select m.MontoInicial).AnyAsync();
                return result;
            }
        }

    }
}
