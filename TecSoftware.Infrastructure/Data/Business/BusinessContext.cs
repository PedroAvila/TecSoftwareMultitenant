using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Business
{
    public class BusinessContext : DbContext
    {
        private List<Conexion> _detalleItemTemp;
        private string _nameTenan = string.Empty;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        //private ITenantProvider _tenantProvider;

        public BusinessContext()
        {

        }

        public BusinessContext(DbContextOptions<BusinessContext> options,
            IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(options)
        {
            //_tenantProvider = tenantProvider;
            //_nameTenan = _tenantProvider.GetName().Result;
            //_detalleItemTemp = _tenantProvider.MostrarConexiones().Result.ToList();

            //var connectionString = configuration["ConnectionStrings:DefaultConnection"];
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;


            if (httpContextAccessor.HttpContext != null)
            {
                _nameTenan = _httpContextAccessor.HttpContext.User.Claims
                .Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).FirstOrDefault().Value;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _nameTenan = DBContextExtensions.CurrentHttpContext.User.Claims
                .Where(c => c.Type == ClaimsIdentity.DefaultNameClaimType).FirstOrDefault().Value;

            //Asignar cadena de conexión
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            _configuration = builder.Build();
            string connectionString = _configuration.GetConnectionString(_nameTenan).ToString();
            optionsBuilder.UseSqlServer(connectionString);
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

            //###### View
            modelBuilder.Entity<SolicitudCotizacionExtend>(c =>
            {
                c.HasNoKey();
                c.ToView("SolicitudCotizacionView");
            });
            modelBuilder.Entity<FacturaExtend>(c =>
            {
                c.HasNoKey();
                c.ToView("ImprimirDocumentosView");
            });
            modelBuilder.Entity<OrdenCompraExtend>(c =>
            {
                c.HasNoKey();
                c.ToView("OrdenCompraView");
            });
            modelBuilder.Entity<ProductoExtend>(c =>
            {
                c.HasNoKey();
                c.ToView("ProductosMasMenosVendidosView");
            });
            modelBuilder.Entity<ProductoExtend>(c =>
            {
                c.HasNoKey();
                c.ToView("ProductosMasMenosRentablesView");
            });
            modelBuilder.Entity<ProductoExtend>(c =>
            {
                c.HasNoKey();
                c.ToView("ProductoSinMovimientoView");
            });
            modelBuilder.Entity<CierreCajaExtend>(c =>
            {
                c.HasNoKey();
                c.ToView("ImprimirCierreCajaView");
            });
            modelBuilder.Entity<RecuentoDenominacionExtend>(c =>
            {
                c.HasNoKey();
                c.ToView("TotalDenominacionView");
            });


            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new EstablecimientoMap());
            modelBuilder.ApplyConfiguration(new PuntoEmisionMap());
            modelBuilder.ApplyConfiguration(new TipoIdentificacionMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ComprobanteMap());
            modelBuilder.ApplyConfiguration(new FormaPagoMap());
            modelBuilder.ApplyConfiguration(new ComprobantePagoMap());
            modelBuilder.ApplyConfiguration(new ImpuestoMap());
            modelBuilder.ApplyConfiguration(new TasaImpuestoMap());
            modelBuilder.ApplyConfiguration(new ProductoMap());
            modelBuilder.ApplyConfiguration(new MonedaMap());
            modelBuilder.ApplyConfiguration(new LaboratorioMap());
            modelBuilder.ApplyConfiguration(new MarcaMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new SubCategoriaMap());
            modelBuilder.ApplyConfiguration(new PresentacionMap());
            modelBuilder.ApplyConfiguration(new ProveedorMap());
            modelBuilder.ApplyConfiguration(new ColorMap());
            modelBuilder.ApplyConfiguration(new TallaMap());
            modelBuilder.ApplyConfiguration(new ListaPrecioMap());
            modelBuilder.ApplyConfiguration(new DetalleComprobantePagoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new OrdenVentaMap());
            modelBuilder.ApplyConfiguration(new DetalleOrdenVentaMap());
            modelBuilder.ApplyConfiguration(new ImpuestoVentaMap());
            modelBuilder.ApplyConfiguration(new EstadoComprobanteElectronicoMap());
            modelBuilder.ApplyConfiguration(new NumeradorOrdenVentaMap());
            modelBuilder.ApplyConfiguration(new NumeradorComprobanteMap());
            modelBuilder.ApplyConfiguration(new MovimientoCajaMap());
            modelBuilder.ApplyConfiguration(new ProductoPrecioMap());
            modelBuilder.ApplyConfiguration(new HistoricoProductoPrecioMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new FuncionMap());
            modelBuilder.ApplyConfiguration(new OperacionMap());
            modelBuilder.ApplyConfiguration(new DenominacionMap());
            modelBuilder.ApplyConfiguration(new RecuentoMap());
            modelBuilder.ApplyConfiguration(new AlmacenMap());
            modelBuilder.ApplyConfiguration(new ProductoAlmacenMap());
            modelBuilder.ApplyConfiguration(new OrdenInventarioMap());
            modelBuilder.ApplyConfiguration(new ProductoOrdenInventarioMap());
            modelBuilder.ApplyConfiguration(new MedidaMap());
            modelBuilder.ApplyConfiguration(new OrdenCompraMap());
            modelBuilder.ApplyConfiguration(new ProductoOrdenCompraMap());
            modelBuilder.ApplyConfiguration(new UbigeoMap());
            modelBuilder.ApplyConfiguration(new OperacionMovimientoMap());
            modelBuilder.ApplyConfiguration(new ProductoOperacionMovimientoMap());
            modelBuilder.ApplyConfiguration(new RegistroInventarioMap());
            modelBuilder.ApplyConfiguration(new ProductoRegistroInventarioMap());
            modelBuilder.ApplyConfiguration(new MovimientoInventarioMap());
            modelBuilder.ApplyConfiguration(new ConceptoInventarioMap());
            modelBuilder.ApplyConfiguration(new RequerimientoCompraMap());
            modelBuilder.ApplyConfiguration(new ProductoRequerimientoMap());
            modelBuilder.ApplyConfiguration(new SolicitudCotizacionMap());
            modelBuilder.ApplyConfiguration(new ProductoCotizacionMap());
            modelBuilder.ApplyConfiguration(new CotizacionProveedorMap());
            modelBuilder.ApplyConfiguration(new ProductoCotizacionProveedorMap());
            modelBuilder.ApplyConfiguration(new CompraMap());
            modelBuilder.ApplyConfiguration(new ProductoCompraMap());
            modelBuilder.ApplyConfiguration(new AreaNegocioMap());
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
