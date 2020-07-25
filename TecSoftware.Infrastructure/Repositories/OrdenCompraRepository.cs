using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Business;

namespace TecSoftware.Infrastructure
{
    public class OrdenCompraRepository : BaseBusinessRepository<OrdenCompra>, IOrdenCompra<OrdenCompra>
    {
        public async Task<string> GenerarCodigo() //IOrdenCompra<OrdenCompra>
        {
            string codigo;
            using (var context = new BusinessContext())
            {
                var result = await context.OrdenCompras.MaxAsync(x => x.NumeroOrden);
                int number = Convert.ToInt32(result);
                codigo = string.Format("{0:0000000000}", number + 1);
                return codigo;
            }
        }



        public async Task Registrar(OrdenCompra entity)
        {
            using (var context = new BusinessContext())
            {
                //VENTA
                context.Entry(entity).State = EntityState.Added;
                //DETALLE
                foreach (var d in entity.ProductoOrdenCompras)
                {
                    context.Entry(d).State = EntityState.Added;
                }
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Reporte Orden de Compra
        /// </summary>
        /// <param name="ordenCompraId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OrdenCompraExtend>> ListarOrdenCompra(int ordenCompraId)
        {
            using (var context = new BusinessContext())
            {
                var result = await context.OrdenCompraExtends.FromSqlRaw(
                    "SELECT oc.NumeroOrden, p.RazonSocial, oc.DireccionEntrega, oc.FechaEmision, oc.FechaEntrega, oc.FormaPago," +
                    " pro.Nombre AS NombreProducto, m.Nombre AS NombreMedida, poc.Cantidad, poc.PrecioUnitario, poc.SubTotal" +
                    " FROM dbo.OrdenCompras oc" +
                    " JOIN dbo.ProductoOrdenCompras poc ON oc.OrdenCompraId = poc.OrdenCompraId" +
                    " JOIN dbo.Proveedores p ON oc.ProveedorId = p.ProveedorId" +
                    " JOIN dbo.Productos pro ON poc.ProductoId = pro.ProductoId" +
                    " JOIN dbo.Medidas m ON poc.MedidaId = m.MedidaId" +
                    " WHERE oc.OrdenCompraId = @ordenCompraId",
                        new SqlParameter("@ordenCompraId", ordenCompraId)).ToListAsync();
                return result;
            }
        }
    }
}
