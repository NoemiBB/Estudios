using System;
using System.Collections.Generic;

namespace AAEstudios.Models
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            Examenes = new HashSet<Examenes>();
        }

        public long AlumnoId { get; set; }
        public string AlumnoNombre { get; set; }

        public virtual ICollection<Examenes> Examenes { get; set; }
    }
}
