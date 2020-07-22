using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure
{
    public class ProductoRepository : BaseRepository<Producto>, IProducto<Producto>
    {
        public async Task AsignarTarifaImpuestos(Producto producto, List<TasaImpuesto> tImpuestos)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                context.Entry(producto).State = EntityState.Unchanged;

                if (producto.TasaImpuestos == null)
                    producto.TasaImpuestos = new List<TasaImpuesto>();

                await Task.Run(() =>
                {
                    //Recorremos cada Modelo que se quiera asociar
                    tImpuestos.ForEach(x =>
                    {
                        //El Modelo tampoco debe recibir cambios
                        context.Entry(x).State = EntityState.Unchanged;
                        //Asociamos a la coleción de Modelo del Proveedor el nuevo item
                        //Este si recibira cambios
                        producto.TasaImpuestos.Add(x);
                        context.SaveChanges();
                    });
                });
            }
        }

        public async Task RemoveTarifaImpuestos(Producto producto, List<TasaImpuesto> tImpuestos)
        {
            //validamos que haya algo que remover
            if (tImpuestos == null || tImpuestos.Count == 0)
                return;

            using (var context = new CatalogoInquilinoContext())
            {
                //recuperamos el terrotorio y sus empleados
                //esto es necesario porque el objeto donde se debe remover tiene que estar dentro del contexto de EF
                Producto productoSel = context.Set<Producto>().Include("TasaImpuestos")
                    .FirstOrDefault(x => x.ProductoId == producto.ProductoId);

                //Proveedor proveedorSel = Context.Proveedores.Include(x => x.Modelos)
                //     .FirstOrDefault(x => x.ProveedorId == proveedor.ProveedorId);

                if (producto.TasaImpuestos == null || producto.TasaImpuestos.Count == 0)
                    return;

                tImpuestos.ForEach(x =>
                {
                    //localizamos al modelo dentro de la coleccion que se recupero anteriormente
                    if (productoSel != null)
                    {
                        TasaImpuesto modeloRemove =
                            productoSel.TasaImpuestos.First(e => e.TasaImpuestoId == x.TasaImpuestoId);
                        //se remueve de la coleccion haciendo uso de la instancia
                        productoSel.TasaImpuestos.Remove(modeloRemove);
                    }
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<List<ICollection<TasaImpuesto>>> TasaImpuestosXProducto(int id)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var list = await context.Productos
                    .Include(c => c.TasaImpuestos)
                    .Where(x => x.ProductoId == id)
                    .Select(c => c.TasaImpuestos).ToListAsync();
                return list;
            }
        }

        public void Registrar(Producto entity)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Producto entity)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                //CABECERA
                //context.Entry(entity).State = EntityState.Modified;
                //DETALLE
                //foreach (var d in entity.EspecificacionProductos)
                //{
                //    context.Entry(d).State = EntityState.Added;
                //}
                //context.SaveChanges();
            }
        }

        public decimal ObtenerPrecioBasae(int id)
        {
            //using (var context = new BusinessContext())
            //{
            //    var resutl = context.Productos
            //        .Where(x => x.ProductoId == id)
            //        .Select(x => x.PrecioBase);
            //    return resutl.FirstOrDefault();
            //}
            throw new NotImplementedException();
        }

        public async Task AsignarTallas(Producto producto, List<Talla> tallas)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                context.Entry(producto).State = EntityState.Unchanged;

                if (producto.Tallas == null)
                    producto.Tallas = new List<Talla>();

                await Task.Run(() =>
                {
                    //Recorremos cada Modelo que se quiera asociar
                    tallas.ForEach(x =>
                    {
                        //El Modelo tampoco debe recibir cambios
                        context.Entry(x).State = EntityState.Unchanged;
                        //Asociamos a la coleción de Modelo del Proveedor el nuevo item
                        //Este si recibira cambios
                        producto.Tallas.Add(x);
                        context.SaveChanges();
                    });
                });
            }
        }

        public async Task RemoveTallas(Producto producto, List<Talla> tallas)
        {
            //validamos que haya algo que remover
            if (tallas == null || tallas.Count == 0)
                return;

            using (var context = new CatalogoInquilinoContext())
            {
                //recuperamos el terrotorio y sus empleados
                //esto es necesario porque el objeto donde se debe remover tiene que estar dentro del contexto de EF
                Producto productoSel = await context.Set<Producto>().Include("Tallas")
                    .FirstOrDefaultAsync(x => x.ProductoId == producto.ProductoId);

                //Proveedor proveedorSel = Context.Proveedores.Include(x => x.Modelos)
                //     .FirstOrDefault(x => x.ProveedorId == proveedor.ProveedorId);

                if (producto.Tallas == null || producto.Tallas.Count == 0)
                    return;

                tallas.ForEach(x =>
                {
                    //localizamos al modelo dentro de la coleccion que se recupero anteriormente
                    if (productoSel != null)
                    {
                        Talla modeloRemove =
                            productoSel.Tallas.First(e => e.TallaId == x.TallaId);
                        //se remueve de la coleccion haciendo uso de la instancia
                        productoSel.Tallas.Remove(modeloRemove);
                    }
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task AsignarColores(Producto producto, List<Colour> colores)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                context.Entry(producto).State = EntityState.Unchanged;

                if (producto.Colores == null)
                    producto.Colores = new List<Colour>();

                await Task.Run(() =>
                {
                    //Recorremos cada Modelo que se quiera asociar
                    colores.ForEach(x =>
                    {
                        //El Modelo tampoco debe recibir cambios
                        context.Entry(x).State = EntityState.Unchanged;
                        //Asociamos a la coleción de Modelo del Proveedor el nuevo item
                        //Este si recibira cambios
                        producto.Colores.Add(x);
                        context.SaveChanges();
                    });
                });
            }
        }

        public async Task RemoveColores(Producto producto, List<Colour> colores)
        {
            //validamos que haya algo que remover
            if (colores == null || colores.Count == 0)
                return;

            using (var context = new CatalogoInquilinoContext())
            {
                //recuperamos el terrotorio y sus empleados
                //esto es necesario porque el objeto donde se debe remover tiene que estar dentro del contexto de EF
                Producto productoSel = await context.Set<Producto>().Include("Colores")
                    .FirstOrDefaultAsync(x => x.ProductoId == producto.ProductoId);

                //Proveedor proveedorSel = Context.Proveedores.Include(x => x.Modelos)
                //     .FirstOrDefault(x => x.ProveedorId == proveedor.ProveedorId);

                if (producto.Colores == null || producto.Colores.Count == 0)
                    return;

                colores.ForEach(x =>
                {
                    //localizamos al modelo dentro de la coleccion que se recupero anteriormente
                    if (productoSel != null)
                    {
                        Colour modeloRemove =
                            productoSel.Colores.First(e => e.ColorId == x.ColorId);
                        //se remueve de la coleccion haciendo uso de la instancia
                        productoSel.Colores.Remove(modeloRemove);
                    }
                });
                await context.SaveChangesAsync();
            }
        }

        //********************************* Proveedores ***************************************

        public async Task AsignarProveedores(Producto producto, List<Proveedor> proveedores)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                context.Entry(producto).State = EntityState.Unchanged;

                if (producto.Proveedores == null)
                    producto.Proveedores = new List<Proveedor>();

                await Task.Run(() =>
                {
                    //Recorremos cada Modelo que se quiera asociar
                    proveedores.ForEach(x =>
                    {
                        //El Modelo tampoco debe recibir cambios
                        context.Entry(x).State = EntityState.Unchanged;
                        //Asociamos a la coleción de Modelo del Proveedor el nuevo item
                        //Este si recibira cambios
                        producto.Proveedores.Add(x);
                        context.SaveChanges();
                    });
                });

            }
        }

        public async Task RemoveProveedores(Producto producto, List<Proveedor> proveedores)
        {
            //validamos que haya algo que remover
            if (proveedores == null || proveedores.Count == 0)
                return;

            using (var context = new CatalogoInquilinoContext())
            {
                //recuperamos el terrotorio y sus empleados
                //esto es necesario porque el objeto donde se debe remover tiene que estar dentro del contexto de EF
                Producto productoSel = await context.Set<Producto>().Include("Proveedores")
                    .FirstOrDefaultAsync(x => x.ProductoId == producto.ProductoId);

                //Proveedor proveedorSel = Context.Proveedores.Include(x => x.Modelos)
                //     .FirstOrDefault(x => x.ProveedorId == proveedor.ProveedorId);

                if (producto.Proveedores == null || producto.Proveedores.Count == 0)
                    return;

                proveedores.ForEach(x =>
                {
                    //localizamos al modelo dentro de la coleccion que se recupero anteriormente
                    if (productoSel != null)
                    {
                        Proveedor modeloRemove =
                            productoSel.Proveedores.First(e => e.ProveedorId == x.ProveedorId);
                        //se remueve de la coleccion haciendo uso de la instancia
                        productoSel.Proveedores.Remove(modeloRemove);
                    }
                });
                await context.SaveChangesAsync();
            }
        }

        public async Task<ProductoExtend> BuscarXCodigo(string valor)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await (from p in context.Productos
                                    join pp in context.ProductoPrecios
                                    on p.ProductoId equals pp.ProductoId

                                    where p.Codigo == valor && p.Estado == ProductoStatus.Activo
                                    select new ProductoExtend()
                                    {
                                        ProductoId = p.ProductoId,
                                        ProductoNombre = p.Nombre,
                                        ProductoPrecioId = pp.ProductoPrecioId,
                                        Pvp = pp.Pvp
                                    }).FirstOrDefaultAsync<ProductoExtend>();
                return result;
            }
        }

        public async Task<IEnumerable<UniversalExtend>> SearchProduct(string valor)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await (from p in context.Productos
                                    join pp in context.ProductoPrecios
                                    on p.ProductoId equals pp.ProductoId
                                    join lp in context.ListaPrecios
                                    on pp.ListaPrecioId equals lp.ListaPrecioId

                                    where p.Nombre.Contains(valor) && p.Estado == ProductoStatus.Activo
                                    select new UniversalExtend()
                                    {
                                        Id = p.ProductoId,
                                        ProductoPrecioId = pp.ProductoPrecioId,
                                        Descripcion = p.Nombre,
                                        Pvp = pp.Pvp,
                                        ListaNombre = lp.Nombre
                                    }).ToListAsync();
                return result;
            }
        }

        public async Task<IEnumerable<ProductoExtend>> BuscarProducto(CriteriaProducto filter)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await (from p in context.Productos
                                    join pp in context.ProductoPrecios
                                    on p.ProductoId equals pp.ProductoId
                                    join lp in context.ListaPrecios
                                    on pp.ListaPrecioId equals lp.ListaPrecioId

                                    where
                                    (filter.Codigo == null || p.Codigo.Contains(filter.Codigo) && p.Estado == ProductoStatus.Activo)
                                    &&
                                    (filter.CodigoBarra == null || p.CodigoBarra.Contains(filter.CodigoBarra) && p.Estado == ProductoStatus.Activo)
                                    &&
                                    (filter.Nombre == null || p.Nombre.Contains(filter.Nombre) && p.Estado == ProductoStatus.Activo)
                                    //&&
                                    //pp.TipoPrecioId == (int)PrecioType.Minorista
                                    select new ProductoExtend()
                                    {
                                        ProductoId = p.ProductoId,
                                        ProductoNombre = p.Nombre,
                                        ProductoPrecioId = pp.ProductoPrecioId,
                                        Pvp = pp.Pvp,
                                        ListaNombre = lp.Nombre
                                    }).ToListAsync();
                return result;
            }
        }

        public async Task<string> GenerarCodigo()
        {
            string codigo;
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await context.Productos.MaxAsync(x => x.Codigo);
                int number = Convert.ToInt32(result);
                codigo = string.Format("{0:0000000000000}", number + 1);
                return codigo;
            }
        }

        public async Task<IEnumerable<ProductoExtend>> ProductoMasVendido(DateTime desde, DateTime hasta)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                //var result = (from cp in context.ComprobantePagos
                //              join dcp in context.DetalleComprobantePagos
                //              on cp.ComprobantePagoId equals dcp.ComprobantePagoId
                //              join p in context.Productos
                //              on dcp.ProductoId equals p.ProductoId
                //              where cp.FechaEmision >= DbFunctions.TruncateTime(desde) && cp.FechaEmision <= DbFunctions.TruncateTime(hasta)
                //              group new { p.Codigo, p.Nombre, dcp.Cantidad } by new { p.Codigo, Nombre = p.Nombre, Cantidad = dcp.Cantidad } into g
                //              select new ProductoExtend()
                //              {
                //                  Codigo = g.Key.Codigo,
                //                  ProductoNombre = g.FirstOrDefault().Nombre,
                //                  TotalVenta = g.Sum(x => x.Cantidad)
                //              }).ToList();

                var result = await context.ProductoExtends.FromSqlRaw(
                    @"SELECT p.Codigo, p.Nombre AS ProductoNombre,
                     SUM(dcp.Cantidad) AS TotalVenta
                     FROM dbo.ComprobantePagos cp
                     JOIN dbo.DetalleComprobantePagos dcp ON cp.ComprobantePagoId = dcp.ComprobantePagoId
                     JOIN dbo.Productos p ON dcp.ProductoId = p.ProductoId
                     WHERE p.Estado = 1 AND cp.FechaEmision BETWEEN @desde AND @hasta
                     GROUP BY p.Codigo, p.Nombre",
                    new SqlParameter("@desde", desde),
                    new SqlParameter("@hasta", hasta)).ToListAsync();
                return result;
            }
        }

        public async Task<IEnumerable<ProductoExtend>> ProductoMasRentable(DateTime desde, DateTime hasta)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await context.ProductoExtends.FromSqlRaw(
                    @"SELECT
                    p.Codigo, p.Nombre AS ProductoNombre,
                    SUM(dcp.Cantidad) AS TotalVenta, SUM(pp.Utilidad) AS Utilidad
                    FROM dbo.ComprobantePagos cp
                    JOIN dbo.DetalleComprobantePagos dcp ON cp.ComprobantePagoId = dcp.ComprobantePagoId
                    JOIN dbo.Productos p ON dcp.ProductoId = p.ProductoId
                    JOIN dbo.ProductoPrecios pp ON p.ProductoId = pp.ProductoId
                    WHERE p.Estado = 1 AND cp.FechaEmision BETWEEN @desde AND @hasta
                    GROUP BY p.Codigo, p.Nombre",
                    //ORDER BY Utilidad DESC"
                    new SqlParameter("@desde", desde),
                    new SqlParameter("@hasta", hasta)).ToListAsync();
                return result;
            }
        }

        public async Task<IEnumerable<ProductoExtend>> ProductoSinMovimiento(DateTime desde, DateTime hasta)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var result = await context.ProductoExtends.FromSqlRaw(
                    @"SELECT p.Codigo, p.Nombre AS ProductoNombre, pp.Utilidad
                    FROM dbo.ProductoPrecios pp
                    JOIN dbo.Productos p ON pp.ProductoId = p.ProductoId
                    WHERE pp.ProductoId NOT IN(
                    SELECT dcp.ProductoId
                    FROM dbo.ComprobantePagos cp
                    JOIN dbo.DetalleComprobantePagos dcp ON cp.ComprobantePagoId = dcp.ComprobantePagoId
                    WHERE cp.FechaEmision BETWEEN @desde AND @hasta)",
                    new SqlParameter("@desde", desde),
                    new SqlParameter("@hasta", hasta)).ToListAsync();
                return result;
            }
        }

    }
}
