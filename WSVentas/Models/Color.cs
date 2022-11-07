using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Color
    {
        public Color()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdColor { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
