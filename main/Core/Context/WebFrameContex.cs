using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Modelos.Empresas;
using Modelos.Financeiro;
using System.IO;

namespace Core.Context
{
    public class WebFrameContex : DbContext
    {
      
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<ContasReceber> ContasReceber { get; set; }

        public WebFrameContex(DbContextOptions<WebFrameContex> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public static string StringConnectionWebFrame()
        {
            var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            var conecxaoAtiva = configuration.GetSection("ConecxaoAtivaWebFrame");

            return configuration.GetConnectionString(conecxaoAtiva.Value);
        }
    }
}
