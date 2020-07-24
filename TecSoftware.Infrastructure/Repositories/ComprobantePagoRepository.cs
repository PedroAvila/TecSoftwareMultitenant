using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    /// <summary>
    /// En esta clase tengo implementado DbEntityValidationExepcionErrors
    /// </summary>
    public class ComprobantePagoRepository : BaseRepository<ComprobantePago>, IComprobantePago<ComprobantePago>
    {
        public async Task Registrar(ComprobantePago entity)
        {
            using (var context = new BusinessContext())
            {
                //VENTA
                context.Entry(entity).State = EntityState.Added;
                //DETALLE
                foreach (var d in entity.DetalleComprobantePagos)
                {
                    context.Entry(d).State = EntityState.Added;
                }
                await context.SaveChangesAsync();
                //try
                //{

                //}
                //catch (DbEntityValidationException e)
                //{
                //    foreach (var eve in e.EntityValidationErrors)
                //    {
                //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //        foreach (var ve in eve.ValidationErrors)
                //        {
                //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                //                ve.PropertyName, ve.ErrorMessage);
                //        }
                //    }
                //}
            }
        }

        /// <summary>
        /// El código númerico de un comprobante de pago es de 8 digitos.
        /// </summary>
        /// <returns></returns>
        public async Task<string> CodigoNumerico()
        {
            using (var context = new BusinessContext())
            {
                var result = await (from cp in context.ComprobantePagos
                                    select cp.CodigoNumerico).MaxAsync();
                var numMax = Convert.ToInt32(result) + 1;
                var number = $"{Convert.ToInt32(numMax):00000000}";
                return number;
            }
        }

        public async Task<IEnumerable<FacturaExtend>> ListarFactura(int comprobantePagoId)
        {
            using (var context = new BusinessContext())
            {
                var result = await context.FacturaExtends.FromSqlRaw(
                    "SELECT cp.NumeroComprobante, cp.FechaEmision, c.RazonSocial, c.Numero, c.Direccion, c2.Nombre AS NombreComprobante," +
                    " pe.Nombre AS NombrePuntoEmision, p.Nombre AS NombreProducto, p2.Abreviacion, dcp.Cantidad, pp.Pvp AS Precio, dcp.TotalDescuento," +
                " pp.Pvp - dcp.TotalDescuento AS Importe, dcp.SubTotalIva, dcp.SubTotalCero, dcp.SubTotalNoObjetoIva, dcp.ValorIva, cp.Total" +
                    " FROM dbo.ComprobantePagos cp" +
                " JOIN dbo.Clientes c ON cp.ClienteId = c.ClienteId" +
                " JOIN dbo.PuntoEmisiones pe ON cp.PuntoEmisionId = pe.PuntoEmisionId" +
                " JOIN dbo.Comprobantes c2 ON cp.ComprobanteId = c2.ComprobanteId" +
                " JOIN dbo.FormaPagos fp ON cp.FormaPagoId = fp.FormaPagoId" +
                " JOIN dbo.DetalleComprobantePagos dcp ON cp.ComprobantePagoId = dcp.ComprobantePagoId" +
                " JOIN dbo.Presentaciones p2 ON dcp.PresentacionId = p2.PresentacionId" +
                " JOIN dbo.Productos p ON dcp.ProductoId = p.ProductoId" +
                " JOIN dbo.ProductoPrecios pp ON dcp.ProductoPrecioId = pp.ProductoPrecioId" +
                " WHERE cp.ComprobantePagoId = @comprobantePagoId}",
                    new SqlParameter("@comprobantePagoId", comprobantePagoId)).ToListAsync();
                return result;
            }
        }
    }
}
