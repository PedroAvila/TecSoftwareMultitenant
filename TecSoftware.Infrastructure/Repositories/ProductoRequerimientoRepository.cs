using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class ProductoRequerimientoRepository : BaseBusinessRepository<ProductoRequerimiento>,
        IProductoRequerimiento<ProductoRequerimiento>
    {
        public async Task<IEnumerable<ProductoRequerimientoExtend>> ListaProductoRequerimiento(int id)
        {
            using (var context = new BusinessContext())
            {
                var result = from pr in context.ProductoRequerimientos
                             join p in context.Productos on pr.ProductoId equals p.ProductoId
                             join m in context.Medidas on pr.MedidaId equals m.MedidaId
                             join an in context.AreaNegocios on pr.AreaNegocioId equals an.AreaNegocioId
                             where pr.RequerimientoCompraId == id
                             select
                             new ProductoRequerimientoExtend()
                             {
                                 ProductoRequerimientoId = pr.ProductoRequerimientoId,
                                 RequerimientoCompraId = pr.RequerimientoCompraId,
                                 ProductoId = pr.ProductoId,
                                 NombreProducto = p.Nombre,
                                 MedidaId = pr.MedidaId,
                                 NombreMedida = m.Nombre,
                                 Cantidad = pr.Cantidad,
                                 AreaNegocioId = pr.AreaNegocioId,
                                 NombreAreaNegocio = an.Nombre
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<IEnumerable<UniversalExtend>> SelectProductoRequerimiento(CriteriaDocumento filter)
        {
            using (var context = new BusinessContext())
            {
                var result = from pr in context.ProductoRequerimientos
                             join rc in context.RequerimientoCompras on pr.RequerimientoCompraId equals rc.RequerimientoCompraId
                             join p in context.Productos on pr.ProductoId equals p.ProductoId
                             join m in context.Medidas on pr.MedidaId equals m.MedidaId
                             where
                             (filter.HasNumber && rc.NumeroRequerimiento.Contains(filter.Numero))
                             ||
                             (filter.HasEstado && (int)rc.Estado == filter.Estado)
                             ||
                             (filter.HasFechaDesde && rc.FechaEmision.Date >= filter.FechaDesde)
                             &&
                             (filter.HasFechaHasta && rc.FechaEmision.Date <= filter.FechaHasta)
                             select
                             new UniversalExtend()
                             {
                                 Id = pr.ProductoRequerimientoId,
                                 NumeroComprobante = rc.NumeroRequerimiento,
                                 ProductoId = pr.ProductoId,
                                 NombreProducto = p.Nombre,
                                 MedidaId = pr.MedidaId,
                                 NombreMedida = m.Nombre,
                                 Cantidad = pr.Cantidad
                             };
                return await result.ToListAsync();
            }
        }
    }
}
