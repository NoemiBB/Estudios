using System;
using System.Collections.Generic;

namespace AAEstudios.Models
{
    public partial class Asignaturas
    {
        public Asignaturas()
        {
            Examenes = new HashSet<Examenes>();
        }

        public long AsignaturaId { get; set; }
        public string AsignaturaNombre { get; set; }
        public string AsignaturaColor { get; set; }

        public virtual ICollection<Examenes> Examenes { get; set; }
    }
}
