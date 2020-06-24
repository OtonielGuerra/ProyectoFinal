using System.Collections.Generic;

namespace ProyectoFinal.Model
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Comentario { get; set; }
        public string Direccion { get; set; }
        public string Estatus { get; set; }
        public string Foto { get; set; }
        public int Telefono { get; set; }
        public List<Clase> Clases { get; set; }
    }
}