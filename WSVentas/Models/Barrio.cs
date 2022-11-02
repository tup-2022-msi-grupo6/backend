using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Barrio
    {
        public Barrio()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int IdBarrio { get; set; }
        public string Nombre { get; set; }
        public int? IdLocalidad { get; set; }

        public virtual Localidad IdLocalidadNavigation { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
