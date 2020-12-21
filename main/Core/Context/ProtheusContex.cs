using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Modelos.Totvs.Protheus.Cadastros;
using Modelos.Totvs.Protheus.Cadastros.Cliente;
using Modelos.Totvs.Protheus.Financeiro;
using Modelos.Totvs.Protheus.Relatorios;
using System.IO;

namespace Core.Context
{
    public class ProtheusContex : DbContext
    {
        public DbSet<SE2010> SE2010 { get; set; }
        public DbSet<SA1010> SA1010 { get; set; }
        public DbSet<RelatorioContasAReceberConsolidado> RelatorioContasAReceberConsolidado { get; set; }
        public DbSet<SE1010> SE1010 { get; set; }
        public DbSet<SED010> SED010 { get; set; }
        public DbSet<TiposTitulos> TiposTitulos { get; set; }

        public ProtheusContex( DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SE2010>().HasNoKey();
            modelBuilder.Entity<RelatorioContasAReceberConsolidado>().HasNoKey();
            modelBuilder.Entity<SE1010>().HasNoKey();
            modelBuilder.Entity<SA1010>().HasNoKey();
            modelBuilder.Entity<SED010>().HasNoKey();
        }
        public static string StringConnectionProtheus()
        {
            var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            var conecxaoAtiva = configuration.GetSection("ConecxaoAtivaProtheus");

            return configuration.GetConnectionString(conecxaoAtiva.Value);
        }
    }
}
