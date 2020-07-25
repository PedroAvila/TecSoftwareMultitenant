using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class CotizacionProveedorRepository : BaseInquilinoRepository<CotizacionProveedor>, ICotizacionProveedor<CotizacionProveedor>
    {
        /// <summary>
        /// No lo etoy usando.
        /// </summary>
        /// <returns></returns>
        public DataSet CotizacionProveedor()
        {
            //using (var context = new BusinessContext())
            //{
            //    var dataSet = new DataSet();
            //    SqlConnection cn = context.Database.Connection as SqlConnection;
            //    SqlDataAdapter adapter = new SqlDataAdapter("SELECT cp.CotizacionProveedorId, cp.NumeroCotizacion, p.RazonSocial AS PROVEEDOR, cp.FechaInicio, cp.FechaFin AS [Fecha Entrega]" +
            //        " FROM dbo.CotizacionProveedores cp" +
            //        " JOIN dbo.Proveedores p ON cp.ProveedorId = p.ProveedorId" +
            //        " WHERE cp.Estado = 2", cn);
            //    adapter.Fill(dataSet, "CotizacionProveedores");

            //    new SqlDataAdapter("SELECT pcp.ProductoCotizacionProveedorId, pcp.CotizacionProveedorId, p.Nombre AS Producto, m.Nombre AS Medida, pcp.FormaPago," +
            //        " pcp.Cantidad, pcp.PrecioCompra, pcp.SubTotal" +
            //        " FROM dbo.ProductoCotizacionProveedores pcp" +
            //        " JOIN dbo.Productos p ON pcp.ProductoId = p.ProductoId" +
            //        " JOIN dbo.Medidas m ON pcp.MedidaId = m.MedidaId", cn).Fill(dataSet, "ProductoCotizacionProveedores");

            //    dataSet.Relations.Add("1", dataSet.Tables["CotizacionProveedores"].Columns["CotizacionProveedorId"],
            //        dataSet.Tables["ProductoCotizacionProveedores"].Columns["CotizacionProveedorId"], false);
            //    return dataSet;
            //}
            throw new NotImplementedException();
        }

        public async Task<string> GenerarCodigo()
        {
            string codigo;
            using (var context = new BusinessContext())
            {
                var result = await context.CotizacionProveedores.MaxAsync(x => x.NumeroCotizacion);
                int number = Convert.ToInt32(result);
                codigo = string.Format("{0:0000000000}", number + 1);
                return codigo;
            }
        }

        public async Task Registrar(CotizacionProveedor entity)
        {
            using (var context = new BusinessContext())
            {
                //VENTA
                context.Entry(entity).State = EntityState.Added;
                //DETALLE
                foreach (var d in entity.ProductoCotizacionProveedores)
                {
                    context.Entry(d).State = EntityState.Added;
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
