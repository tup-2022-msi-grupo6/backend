using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Localidad
    {
        public Localidad()
        {
            Barrio = new HashSet<Barrio>();
        }

        public int IdLocalidad { get; set; }
        public string Nombre { get; set; }
        public int? IdProvincia { get; set; }

        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<Barrio> Barrio { get; set; }
    }
}
