using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Catalogo
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



    }
}
