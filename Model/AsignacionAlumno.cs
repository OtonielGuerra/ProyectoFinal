using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Model
{
    public class AsignacionAlumno
    {
        [Key]
        public int AsignacionId { get; set; }
        public int AlumnoId { get; set; }
        public int ClaseId { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public Alumno Alumno { get; set; }
    }
}