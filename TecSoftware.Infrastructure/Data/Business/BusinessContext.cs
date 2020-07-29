using Microsoft.EntityFrameworkCore;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class BusinessContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //### ComprobanteTipoIdentificacion
            modelBuilder.Entity<ComprobanteTipoIdentificacion>()
                .HasKey(c => new { c.ComprobanteId, c.TipoIdentificacionId });

            modelBuilder.Entity<ComprobanteTipoIdentificacion>()
                .HasOne(ct => ct.Comprobante)
                .WithMany(c => c.ComprobanteTipoIdentificaciones)
                .HasForeignKey(ct => ct.ComprobanteId);

            modelBuilder.Entity<ComprobanteTipoIdentificacion>()
                .HasOne(ct => ct.TipoIdentificacion)
                .WithMany(t => t.ComprobanteTipoIdentificaciones)
                .HasForeignKey(ct => ct.TipoIdentificacionId);

            //### ProductoTasaImpuestos
            modelBuilder.Entity<ProductoTasaImpuesto>()
                .HasKey(c => new { c.ProductoId, c.TasaImpuestoId });

            modelBuilder.Entity<ProductoTasaImpuesto>()
                .HasOne(pt => pt.Producto)
                .WithMany(p => p.ProductoTasaImpuestos)
                .HasForeignKey(pt => pt.ProductoId);

            modelBuilder.Entity<ProductoTasaImpuesto>()
                .HasOne(pt => pt.TasaImpuesto)
                .WithMany(t => t.ProductoTasaImpuestos)
                .HasForeignKey(pt => pt.TasaImpuestoId);

            //### ProductoColores
            modelBuilder.Entity<ProductoColor>()
                .HasKey(c => new { c.ProductoId, c.ColorId });

            modelBuilder.Entity<ProductoColor>()
                .HasOne(pc => pc.Producto)
                .WithMany(p => p.ProductoColores)
                .HasForeignKey(pc => pc.ProductoId);

            modelBuilder.Entity<ProductoColor>()
                .HasOne(pc => pc.Colour)
                .WithMany(c => c.ProductoColores)
                .HasForeignKey(pc => pc.ColorId);

            //### ProductoTallas
            modelBuilder.Entity<ProductoTalla>()
                .HasKey(c => new { c.ProductoId, c.TallaId });

            modelBuilder.Entity<ProductoTalla>()
                .HasOne(pt => pt.Producto)
                .WithMany(p => p.ProductoTallas)
                .HasForeignKey(pt => pt.ProductoId);

            modelBuilder.Entity<ProductoTalla>()
                .HasOne(pt => pt.Talla)
                .WithMany(t => t.ProductoTallas)
                .HasForeignKey(pt => pt.TallaId);

            //### ProductoProveedores
            modelBuilder.Entity<ProductoProveedor>()
                .HasKey(c => new { c.ProductoId, c.ProveedorId });

            modelBuilder.Entity<ProductoProveedor>()
                .HasOne(pp => pp.Producto)
                .WithMany(p => p.ProductoProveedores)
                .HasForeignKey(pp => pp.ProductoId);

            modelBuilder.Entity<ProductoProveedor>()
                .HasOne(pp => pp.Proveedor)
                .WithMany(p => p.ProductoProveedores)
                .HasForeignKey(pp => pp.ProveedorId);

            //### RolFunciones
            modelBuilder.Entity<RolFuncion>()
                .HasKey(c => new { c.RolId, c.FuncionId });

            modelBuilder.Entity<RolFuncion>()
                .HasOne(rf => rf.Rol)
                .WithMany(r => r.RolFunciones)
                .HasForeignKey(rf => rf.RolId);

            modelBuilder.Entity<RolFuncion>()
                .HasOne(rf => rf.Funcion)
                .WithMany(f => f.RolFunciones)
                .HasForeignKey(rf => rf.FuncionId);

            modelBuilder.ApplyConfiguration(new EmpresaMap());
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Establecimiento> Establecimientos { get; set; }
        public DbSet<PuntoEmision> PuntoEmisiones { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificaciones { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Comprobante> Comprobantes { get; set; }
        public DbSet<FormaPago> FormaPagos { get; set; }
        public DbSet<ComprobantePago> ComprobantePagos { get; set; }
        public DbSet<Impuesto> Impuestos { get; set; }
        public DbSet<TasaImpuesto> TasaImpuestos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Presentacion> Presentaciones { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Colour> Colores { get; set; }
        public DbSet<Talla> Tallas { get; set; }
        public DbSet<ListaPrecio> ListaPrecios { get; set; }
        public DbSet<DetalleComprobantePago> DetalleComprobantePagos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<OrdenVenta> OrdenVentas { get; set; }
        public DbSet<DetalleOrdenVenta> DetalleOrdenVentas { get; set; }
        public DbSet<ImpuestoVenta> ImpuestoVentas { get; set; }
        public DbSet<EstadoComprobanteElectronico> EstadoComprobanteElectronicos { get; set; }
        public DbSet<NumeradorOrdenVenta> NumeradorOrdenVentas { get; set; }
        public DbSet<NumeradorComprobante> NumeradorComprobantes { get; set; }
        public DbSet<MovimientoCaja> MovimientoCajas { get; set; }
        public DbSet<ProductoPrecio> ProductoPrecios { get; set; }
        public DbSet<HistoricoProductoPrecio> HistoricoProductoPrecios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
        public DbSet<Denominacion> Denominaciones { get; set; }
        public DbSet<Recuento> Recuentos { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<ProductoAlmacen> ProductoAlmacenes { get; set; }
        public DbSet<OrdenInventario> OrdenInventarios { get; set; }
        public DbSet<ProductoOrdenInventario> ProductoOrdenInventarios { get; set; }
        public DbSet<Medida> Medidas { get; set; }
        public DbSet<OrdenCompra> OrdenCompras { get; set; }
        public DbSet<ProductoOrdenCompra> ProductoOrdenCompras { get; set; }
        public DbSet<Ubigeo> Ubigeos { get; set; }
        public DbSet<OperacionMovimiento> OperacionMovimientos { get; set; }
        public DbSet<ProductoOperacionMovimiento> ProductoOperacionMovimientos { get; set; }
        public DbSet<RegistroInventario> RegistroInventarios { get; set; }
        public DbSet<ProductoRegistroInventario> ProductoRegistroInventarios { get; set; }
        public DbSet<MovimientoInventario> MovimientoInventarios { get; set; }
        public DbSet<ConceptoInventario> ConceptoInventarios { get; set; }
        public DbSet<RequerimientoCompra> RequerimientoCompras { get; set; }
        public DbSet<ProductoRequerimiento> ProductoRequerimientos { get; set; }
        public DbSet<SolicitudCotizacion> SolicitudCotizaciones { get; set; }
        public DbSet<ProductoCotizacion> ProductoCotizaciones { get; set; }
        public DbSet<CotizacionProveedor> CotizacionProveedores { get; set; }
        public DbSet<ProductoCotizacionProveedor> ProductoCotizacionProveedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ProductoCompra> ProductoCompras { get; set; }
        public DbSet<AreaNegocio> AreaNegocios { get; set; }


        public DbSet<SolicitudCotizacionExtend> SolicitudCotizacionExtends { get; set; }
        public DbSet<FacturaExtend> FacturaExtends { get; set; }
        public DbSet<OrdenCompraExtend> OrdenCompraExtends { get; set; }
        public DbSet<ProductoExtend> ProductoExtends { get; set; }
        public DbSet<CierreCajaExtend> CierreCajaExtends { get; set; }
        public DbSet<RecuentoDenominacionExtend> RecuentoDenominacionExtends { get; set; }
    }

}
