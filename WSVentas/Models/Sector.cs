using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Sector
    {
        public Sector()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdSector { get; set; }
        public string Descripcion { get; set; }
        public int? IdEstante { get; set; }

        public virtual Estante IdEstanteNavigation { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
