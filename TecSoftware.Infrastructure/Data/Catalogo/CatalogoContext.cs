using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Infrastructure.Data.Catalogo
{
    public class CatalogoContext : DbContext
    {
        private IConfiguration _configuration;


        public CatalogoContext()
        {

        }

        public CatalogoContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
            //_detalleItemTemp = tenantProvider.GetConexions();
            //_nameTenan = tenantProvider.GetName();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            _configuration = builder.Build();
            string connectionString = _configuration.GetConnectionString("CatalogoInquilino").ToString();
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InquilinoMap());
            modelBuilder.ApplyConfiguration(new BaseDatoMap());
            modelBuilder.ApplyConfiguration(new ServidorMap());
        }


        public virtual DbSet<Inquilino> Inquilinos { get; set; }
        public virtual DbSet<BaseDato> BaseDatos { get; set; }
        public virtual DbSet<Servidor> Servidores { get; set; }
    }
}
