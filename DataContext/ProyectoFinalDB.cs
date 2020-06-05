using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoFinal.Model;

namespace ProyectoFinal.DataContext
{
    public class ProyectoFinalDB : DbContext
    {
        public ProyectoFinalDB(DbContextOptions<ProyectoFinalDB> options) 
            : base(options) 
        {
        }
        public ProyectoFinalDB()
        {
        }
        public DbSet<Alumno> Alumnos {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}