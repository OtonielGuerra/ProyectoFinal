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
        public DbSet<Salon> Salones { get; set; }
        public DbSet<Carrera> CarrerasTecnicas { get; set; }
        public DbSet<Instructor> Instructores { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<AsignacionAlumno> AsignacionAlumnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}