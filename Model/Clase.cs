namespace ProyectoFinal.Model
{
    public class Clase
    {
        public int ClaseId { get; set; }
        public int Ciclo { get; set; }
        public int CupoMaximo { get; set; }
        public int CupoMinimo { get; set; } 
        public string Descripcion { get; set; }
        public int CarreraId { get; set; }
        public int HorarioId { get; set; }
        public int InstructorId { get; set; }
        public int SalonId { get; set; }
        public Carrera Carrera { get; set; }
        public Horario Horario { get; set; }
        public Instructor Instructor { get; set; }
        public Salon Salon { get; set; }
    }
}