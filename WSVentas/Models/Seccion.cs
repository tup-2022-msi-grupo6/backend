using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Seccion
    {
        public Seccion()
        {
            Estante = new HashSet<Estante>();
        }

        public int IdSeccion { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Estante> Estante { get; set; }
    }
}
