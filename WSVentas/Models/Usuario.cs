using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Empleado = new HashSet<Empleado>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public int? IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
