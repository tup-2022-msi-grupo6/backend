using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class TipoPintura
    {
        public TipoPintura()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdTipo { get; set; }
        public string Titulo { get; set; }
        public string TipoPintura1 { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
