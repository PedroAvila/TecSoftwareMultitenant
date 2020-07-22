using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;


namespace TecSoftware.Infrastructure
{
    public class ProductoCotizacionRepository : BaseRepository<ProductoCotizacion>,
        IProductoCotizacion<ProductoCotizacion>
    {
        public async Task<IEnumerable<ProductoCotizacionExtend>> ListaProductoCotizacion(int id)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = from pc in context.ProductoCotizaciones
                             join p in context.Productos on pc.ProductoId equals p.ProductoId
                             join m in context.Medidas on pc.MedidaId equals m.MedidaId
                             where pc.SolicitudCotizacionId == id
                             select
                             new ProductoCotizacionExtend()
                             {
                                 ProductoCotizacionId = pc.ProductoCotizacionId,
                                 SolicitudCotizacionId = pc.SolicitudCotizacionId,
                                 ProductoRequerimientoId = pc.ProductoRequerimientoId,
                                 ProductoId = pc.ProductoId,
                                 NombreProducto = p.Nombre,
                                 MedidaId = pc.MedidaId,
                                 NombreMedida = m.Nombre,
                                 FormaPago = pc.FormaPago,
                                 Cantidad = pc.Cantidad,
                                 Precio = pc.Precio
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<int> ObtenerIdProductoCotizacion(string numeroCotizacion, int productoId)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await (from pc in context.ProductoCotizaciones
                                    join sc in context.SolicitudCotizaciones on pc.SolicitudCotizacionId equals sc.SolicitudCotizacionId
                                    where sc.NumeroCotizacion == numeroCotizacion && pc.ProductoId == productoId
                                    select pc.ProductoCotizacionId).FirstOrDefaultAsync();
                return Convert.ToInt32(result);
            }
        }

    }
}
