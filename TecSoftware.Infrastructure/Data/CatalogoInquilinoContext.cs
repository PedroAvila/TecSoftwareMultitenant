using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data;

namespace TecSoftware.Infrastructure
{
    public class CatalogoInquilinoContext : DbContext
    {
        private IConfiguration _configuration;
        
        public CatalogoInquilinoContext() : base()
        {

        }

        public CatalogoInquilinoContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            _configuration = builder.Build();
            string connectionString = _configuration.GetConnectionString("CatalogoInquilino").ToString();
            options.UseSqlServer(connectionString);
        }


        public virtual DbSet<Inquilino> Inquilinos { get; set; }
        public virtual DbSet<BaseDato> BaseDatos { get; set; }
        public virtual DbSet<Servidor> Servidores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InquilinoMap());
            modelBuilder.ApplyConfiguration(new BaseDatoMap());
            modelBuilder.ApplyConfiguration(new ServidorMap());
        }
    }
}
