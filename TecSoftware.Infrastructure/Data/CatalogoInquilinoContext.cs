using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data;

namespace TecSoftware.Infrastructure
{
    public class CatalogoInquilinoContext : DbContext
    {
        private IConfiguration _configuration;
        private List<Conexion> _detalleItemTemp;
        private string _nameTenan = string.Empty;

        public CatalogoInquilinoContext()
        {

        }

        public CatalogoInquilinoContext(DbContextOptions options, IConfiguration configuration, ITenantProvider tenantProvider)
            : base(options)
        {
            _configuration = configuration;
            _detalleItemTemp = tenantProvider.GetConexions();
            _nameTenan = tenantProvider.GetName();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(_nameTenan))
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("appsettings.json", optional: false);
                _configuration = builder.Build();
                string connectionString = _configuration.GetConnectionString("CatalogoInquilino").ToString();
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                var ConnectionString = _detalleItemTemp.Where(x => x.Tenant == _nameTenan)
                    .FirstOrDefault().DatabaseConnectionString;
                optionsBuilder.UseSqlServer(ConnectionString);
            }


            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InquilinoMap());
            modelBuilder.ApplyConfiguration(new BaseDatoMap());
            modelBuilder.ApplyConfiguration(new ServidorMap());
            //modelBuilder.Query<SolicitudCotizacionExtend>().ToView("SolicitudCotizacionView");
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
        }


        public virtual DbSet<Inquilino> Inquilinos { get; set; }
        public virtual DbSet<BaseDato> BaseDatos { get; set; }
        public virtual DbSet<Servidor> Servidores { get; set; }

        //***************** NEGOCIOS *************************

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
