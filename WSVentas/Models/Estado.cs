using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Envio = new HashSet<Envio>();
        }

        public int IdEstado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Envio> Envio { get; set; }
    }
}
