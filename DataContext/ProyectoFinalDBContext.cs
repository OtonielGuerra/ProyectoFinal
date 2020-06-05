using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProyectoFinal.DataContext
{
    public class ProyectoFinalDBContext : IDesignTimeDbContextFactory<ProyectoFinalDB>
    {
        public ProyectoFinalDBContext()
        {
            
        }

        public ProyectoFinalDB CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

            var optionBuilder = new DbContextOptionsBuilder<ProyectoFinalDB>();
            optionBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new ProyectoFinalDB(optionBuilder.Options);
        }
    }
}