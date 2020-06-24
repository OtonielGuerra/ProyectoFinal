using System.Collections.Generic;

namespace ProyectoFinal.Model
{
    public class Salon
    {
        public int SalonId { get; set; }
        public int Capacidad { get; set; }
        public string Descripcion { get; set; }
        public string NombreSalon { get; set; }
        public List<Clase> Clases { get; set; }
    }
}