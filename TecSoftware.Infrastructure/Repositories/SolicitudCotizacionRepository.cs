using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Persistencia
{
    public class SolicitudCotizacionRepository : BaseBusinessRepository<SolicitudCotizacion>, ISolicitudCotizacion<SolicitudCotizacion>
    {
        public async Task<string> GenerarCodigo()
        {
            string codigo;
            using (var context = new BusinessContext())
            {
                var result = await context.SolicitudCotizaciones.MaxAsync(x => x.NumeroCotizacion);
                int number = Convert.ToInt32(result);
                codigo = string.Format("{0:0000000000}", number + 1);
                return codigo;
            }
        }

        public async Task<IEnumerable<UniversalExtend>> SelectSolicitudCotizacion(CriteriaDocumento filter)
        {
            using (var context = new BusinessContext())
            {
                var result = from sc in context.SolicitudCotizaciones
                             join p in context.Proveedores on sc.ProveedorId equals p.ProveedorId
                             where
                             (filter.HasNumber && sc.NumeroCotizacion.Contains(filter.Numero))
                             ||
                             (filter.HasEstado && (int)sc.Estado == filter.Estado)
                             ||
                             (filter.HasFechaDesde && sc.FechaEmision.Date >= filter.FechaDesde)
                             &&
                             (filter.HasFechaHasta && sc.FechaEmision.Date <= filter.FechaHasta)
                             select
                             new UniversalExtend()
                             {
                                 Id = sc.SolicitudCotizacionId,
                                 NumeroComprobante = sc.NumeroCotizacion,
                                 FechaEmision = sc.FechaEmision,
                                 EstadoSolicitudCotizacion = sc.Estado,
                                 Nombre = p.RazonSocial
                             };
                return await result.ToListAsync();
            }
        }

        public async Task Registrar(SolicitudCotizacion entity)
        {
            using (var context = new BusinessContext())
            {
                //CABECERA
                context.Entry(entity).State = EntityState.Added;
                //DETALLE
                foreach (var d in entity.ProductoCotizaciones)
                {
                    context.Entry(d).State = EntityState.Added;
                }
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SolicitudCotizacionExtend>> ListarSolicitudCotizacion(int solicitudCotizacionId)
        {
            using (var context = new BusinessContext())
            {
                var result = await context.SolicitudCotizacionExtends.FromSqlRaw(
                    @"SELECT sc.NumeroCotizacion, sc.FechaEmision, sc.FechaEntrega, prv.RazonSocial,
                    prv.Direccion, pc.ProductoId, p.Nombre AS NombreProducto, m.Nombre AS NombreMedida, pc.FormaPago, pc.Cantidad, pc.Precio
                    FROM dbo.SolicitudCotizaciones sc
                    JOIN dbo.Proveedores prv ON sc.ProveedorId = prv.ProveedorId
                    JOIN dbo.ProductoCotizaciones pc ON sc.SolicitudCotizacionId = pc.SolicitudCotizacionId
                    JOIN dbo.Productos p ON pc.ProductoId = p.ProductoId
                    JOIN dbo.Medidas m ON pc.MedidaId = m.MedidaId
                    WHERE sc.SolicitudCotizacionId = {solicitudCotizacionId}").ToListAsync();

                return result;
            }
        }

        public async Task UpdateSolicitudCotizacion(int id, SolicitudCotizacionStatus estado)
        {
            using (var context = new BusinessContext())
            {
                var query = (from sc in context.SolicitudCotizaciones
                             where sc.SolicitudCotizacionId == id
                             select sc).FirstOrDefault();
                query.Estado = estado;
                await context.SaveChangesAsync();
            }
        }

    }
}
