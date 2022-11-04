using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSVentas.Models.Request
{
    public class UsuarioRequest
    {
        public int idUsuario { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public int id_rol { get; set; }

    }
}
