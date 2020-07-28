using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.BusinessException;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;

namespace TecSoftware.Core
{
    public class SdProductoPrecio
    {
        private readonly ProductoPrecioRepository _productoPrecioRepository = new ProductoPrecioRepository();

        private readonly HistoricoProductoPrecioRepository _historicoProductoPrecioRepository =
            new HistoricoProductoPrecioRepository();
        //private readonly int _productoId;
        //private readonly decimal _cantidad;

        public ProductoPrecio CalcularPrecioUtilidad(ProductoPrecio entity)
        {
            var porcentaje = entity.Utilidad / 100M;
            var utilidad = entity.PrecioCompra * porcentaje;
            var result = entity.PrecioCompra + utilidad;
            //var result = (entity.PrecioCompra * 10000 / (100 + entity.Utilidad)) / 100;
            entity.Pvp = result;
            return entity;
        }

        public ProductoPrecio CalcularPrecioPvP(ProductoPrecio entity)
        {
            var resta = entity.Pvp - entity.PrecioCompra;
            var result = (100 * resta) / entity.PrecioCompra;
            entity.Utilidad = result;
            return entity;
        }

        public async Task<ProductoPrecio> Single(Expression<Func<ProductoPrecio, bool>> predicate,
            List<Expression<Func<ProductoPrecio, object>>> includes)
        {
            return await _productoPrecioRepository.Single(predicate, includes);
        }

        public async Task Create(ProductoPrecio entity)
        {
            if (entity.ProductoPrecioId != default)
            { //Si precio de compra o precio de venta es difrente se crea un registro en historico y se actualiza ProductoPrecio.  
                bool exist = await _productoPrecioRepository.Exist(x => x.PrecioCompra != entity.PrecioCompra
                || x.Pvp != entity.Pvp);
                if (exist)
                { //Traigo los datos de ProductoPrecio y los inserto en Historico
                    var precioOld = await _productoPrecioRepository.Single(x => x.ProductoPrecioId == entity.ProductoPrecioId);
                    if (precioOld != null)
                    {
                        var historico = new HistoricoProductoPrecio()
                        {
                            ProductoPrecioId = precioOld.ProductoPrecioId,
                            TipoPrecioId = precioOld.TipoPrecioId,
                            CantidadMinima = precioOld.CantidadMinima,
                            CantidadMaxima = precioOld.CantidadMaxima ?? 0,
                            PrecioCompra = precioOld.PrecioCompra,
                            Utilidad = precioOld.Utilidad,
                            Pvp = precioOld.Pvp,
                            FechaUpdate = DateTime.Now
                        };
                        await _historicoProductoPrecioRepository.Create(historico);//Los nuevos datos los actualizo en ProductoPrecio.
                    }
                }
                await _productoPrecioRepository.Update(entity);
            }
            else
            {
                bool exist = await _productoPrecioRepository.Exist(x => x.ProductoId == entity.ProductoId
                && x.TipoPrecioId == entity.TipoPrecioId && x.Pvp == entity.Pvp);
                if (exist)
                    throw new CustomException("El Precio que intenta registrar ya existe.");
                await _productoPrecioRepository.Create(entity);
            }
        }

        public async Task<IEnumerable<ProductoPrecio>> Filter(Expression<Func<ProductoPrecio, bool>> predicate)
        {
            return await _productoPrecioRepository.Filter(predicate);
        }

        public async Task<IEnumerable<ProductoPrecioExtend>> ListaProductoPrecio(int id)
        {
            return await _productoPrecioRepository.ListaProductoPrecio(id);
        }

        public async Task Delete(Expression<Func<ProductoPrecio, bool>> predicate)
        {
            try
            {
                await _productoPrecioRepository.Delete(predicate);
            }
            catch (CustomException)
            {
                throw new CustomException("No puede eliminar el producto de la lista\nPorque ya fue vendido" +
                    "ó actualizo su precio");
            }
        }

        public async Task<bool> Exist(Expression<Func<ProductoPrecio, bool>> predicate)
        {
            return await _productoPrecioRepository.Exist(predicate);
        }
    }
}
