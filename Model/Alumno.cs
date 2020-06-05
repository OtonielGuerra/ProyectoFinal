using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Model
{
    public class Alumno
    {
        public int AlumnoId { get; set; }
        public int Carne { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
    }
}