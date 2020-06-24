using System.Collections.Generic;

namespace ProyectoFinal.Model
{
    public class Carrera
    {
        public int CarreraId { get; set; }
        public string Nombre { get; set; }
        public List<Clase> Clases { get; set; }
        
    }
}