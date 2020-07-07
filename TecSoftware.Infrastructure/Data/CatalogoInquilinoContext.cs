using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data;

namespace TecSoftware.Infrastructure
{
    public class CatalogoInquilinoContext : DbContext
    {
        private IConfiguration _configuration;
        private InquilinoExtend _inquilino;
        private ITenantProvider _tenantProvider;

        public CatalogoInquilinoContext() : base()
        {

        }

        public CatalogoInquilinoContext(DbContextOptions options, IConfiguration configuration, ITenantProvider tenantProvider)
            : base(options)
        {
            _configuration = configuration;
            _inquilino = tenantProvider.GetTenant();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_inquilino == null)
            {
                var builder = new ConfigurationBuilder();
                builder.AddJsonFile("appsettings.json", optional: false);
                _configuration = builder.Build();
                string connectionString = _configuration.GetConnectionString("CatalogoInquilino").ToString();
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
                optionsBuilder.UseSqlServer(_inquilino.DatabaseConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InquilinoMap());
            modelBuilder.ApplyConfiguration(new BaseDatoMap());
            modelBuilder.ApplyConfiguration(new ServidorMap());
            modelBuilder.ApplyConfiguration(new PruebaMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
        }


        public virtual DbSet<Inquilino> Inquilinos { get; set; }
        public virtual DbSet<BaseDato> BaseDatos { get; set; }
        public virtual DbSet<Servidor> Servidores { get; set; }
        public virtual DbSet<Prueba> Pruebas { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }

        public void CreatePrueba()
        {
            var pais = new Pais()
            {
                Nombre = "Peru",
                Developer = "Pedro Avila"
            };
            Paises.Add(pais);
            SaveChanges();
        }
    }
}
