using System.Collections.Generic;

using System;

namespace ProyectoFinal.Model
{
    public class Horario
    {
        public int HorarioId { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFinal { get; set; }
        public List<Clase> Clases { get; set; }
    }
}