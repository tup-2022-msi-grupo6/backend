using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WSVentas.Tools;

namespace WSVentas.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int NroFac { get; set; }
        public int IdCliente { get; set; }
        public int? IdFormaPago { get; set; }
        public DateTime FechaVenta { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdEnvio { get; set; }
        public decimal Total { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual Envio IdEnvioNavigation { get; set; }
        public virtual FormaPago IdFormaPagoNavigation { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
