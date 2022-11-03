using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdEmpleado { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int? Dni { get; set; }
        public string Cargo { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
