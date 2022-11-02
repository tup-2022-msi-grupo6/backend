using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Envio
    {
        public Envio()
        {
            Venta = new HashSet<Venta>();
        }

        public int IdEnvio { get; set; }
        public int? IdEstado { get; set; }
        public string Direccion { get; set; }
        public int? IdCliente { get; set; }
        public int? CodigoProducto { get; set; }

        public virtual Producto CodigoProductoNavigation { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
