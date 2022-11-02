using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class FormaPago
    {
        public FormaPago()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdFormaPago { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
