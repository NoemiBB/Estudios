using System;
using System.Collections.Generic;

namespace AAEstudios.Models
{
    public partial class Examenes
    {
        public long AlumnoId { get; set; }
        public long AsignaturaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tema { get; set; }
        public string Observaciones { get; set; }
        public string Nota { get; set; }

        public virtual Alumnos Alumno { get; set; }
        public virtual Asignaturas Asignatura { get; set; }
    }
}
