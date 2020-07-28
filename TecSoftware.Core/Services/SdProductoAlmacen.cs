using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProductoAlmacen
    {
        private readonly ProductoAlmacenRepository _productoAlmacenRepository = new ProductoAlmacenRepository();
        private readonly SdMovimientoInventario _sdMovimientoInventario = new SdMovimientoInventario();

        public async Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<ProductoAlmacen, UniversalExtend>> source)
        {
            return await _productoAlmacenRepository.SelectList(source);
        }

        public async Task<IEnumerable<UniversalExtend>> SelectList
            (Expression<Func<ProductoAlmacen, bool>> predicate, Expression<Func<ProductoAlmacen, UniversalExtend>> source)
        {
            return await _productoAlmacenRepository.SelectList(predicate, source);
        }

        //public IEnumerable<UniversalExtend> ListarBodega
        //    (Expression<Func<Almacen, bool>> predicate, Expression<Func<Almacen, UniversalExtend>> source)
        //{
        //    var listaItem = SelectList(predicate, source).ToList();
        //    listaItem.Insert(0, new UniversalExtend() { Id = -1, Descripcion = "<<<Seleccione>>>" });
        //    return listaItem;
        //}

        public async Task<ProductoAlmacen> Single(Expression<Func<ProductoAlmacen, bool>> predicate)
        {
            return await _productoAlmacenRepository.Single(predicate);
        }

        public async Task Create(ProductoAlmacen entity)
        {
            if (entity.ProductoAlmacenId != default)
                await _productoAlmacenRepository.Update(entity);
            else
            {
                bool exist = await _productoAlmacenRepository.Exist(x =>

                x.AlmacenId == entity.AlmacenId && x.ProductoId == entity.ProductoId
                     && x.PresentacionId == entity.PresentacionId);
                if (exist)
                    throw new CustomException("El producto almacén que intenta registrar ya existe.");
                await _productoAlmacenRepository.Create(entity);
            }
        }

        public async Task Delete(Expression<Func<ProductoAlmacen, bool>> predicate)
        {
            await _productoAlmacenRepository.Delete(predicate);
        }

        public async Task<IEnumerable<ProductoAlmacenExtend>> ListaProductoAlmacen(int id)
        {
            return await _productoAlmacenRepository.ListaProductoAlmacen(id);
        }

        public void ActualizarSaldosCostos(RegistroInventario registroInventario, ProductoOrdenInventario entity)
        {
            MovimientoInventario movimientoInventario = new MovimientoInventario();
            movimientoInventario.ProductoAlmacenId = registroInventario.AlmacenId;
            foreach (var item in registroInventario.OperacionMovimiento.ProductoOperacionMovimientos)
            {
                movimientoInventario.ProductoOperacionMovimientoId = item.Id;
            }
            foreach (var item in registroInventario.ProductoRegistroInventarios)
            {
                movimientoInventario.ProductoRegistroInventarioId = item.Id;
            }
            var cantidadSaldoFinal = _sdMovimientoInventario.ObtenerCantidadSaldoFinal(entity.ProductoId);
            //Saldo Inicial
            if (cantidadSaldoFinal == (decimal)0)
            {
                movimientoInventario.CantidadSaldoInicial = entity.Cantidad;
                movimientoInventario.CostoUnitarioSaldoInicial = (decimal)(6.00);
                movimientoInventario.CostoTotalSaldoInical
                    = movimientoInventario.CantidadSaldoInicial * movimientoInventario.CostoUnitarioSaldoInicial;


            }
            //Entrada
            if (registroInventario.TipoRegistroInventario == TipoRegistroInventario.Entrada)
            {

            }
            //Salida
            if (registroInventario.TipoRegistroInventario == TipoRegistroInventario.Salida)
            {

            }

            //SaldoFinal
            movimientoInventario.CantidadSaldoFinal = movimientoInventario.CantidadSaldoInicial + (movimientoInventario.CantidadEntrada - movimientoInventario.CantidadSalida);
            movimientoInventario.CostoUnitarioSaldoFinal = (movimientoInventario.CostoUnitarioSaldoInicial + movimientoInventario.CostoUnitarioEntrada) / 2;
            movimientoInventario.CostoTotalSaldoFinal = movimientoInventario.CantidadSaldoFinal * movimientoInventario.CostoUnitarioSaldoFinal;

            //Persistir en Movimiento Inventario
            movimientoInventario.FechaOperacionInventario = DateTime.Now;
            _sdMovimientoInventario.Create(movimientoInventario);
            //_sdMovimientoInventario.
            //Actualizar en ProductoAlmacen
            _productoAlmacenRepository.UpdateProductoAlmacen
            (entity.ProductoId, entity.AlmacenId, movimientoInventario.CostoTotalSaldoInical);
        }


    }
}
