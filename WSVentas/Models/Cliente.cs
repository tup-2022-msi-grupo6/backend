using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Envio = new HashSet<Envio>();
            Venta = new HashSet<Venta>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public decimal? Telefono { get; set; }
        public int? Dni { get; set; }
        public string Email { get; set; }
        public int? IdBarrio { get; set; }

        public virtual Barrio IdBarrioNavigation { get; set; }
        public virtual ICollection<Envio> Envio { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
