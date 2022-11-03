using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Estante
    {
        public Estante()
        {
            Sector = new HashSet<Sector>();
        }

        public int IdEstante { get; set; }
        public string Descripcion { get; set; }
        public int? IdSeccion { get; set; }

        public virtual Seccion IdSeccionNavigation { get; set; }
        public virtual ICollection<Sector> Sector { get; set; }
    }
}
