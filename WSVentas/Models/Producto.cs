using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
            Envio = new HashSet<Envio>();
        }

        public int Codigo { get; set; }
        public string TipoProducto { get; set; }
        public string Descripcion { get; set; }
        public int? IdTipoPintura { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public string Acabado { get; set; }
        public int? Tamaño { get; set; }
        public double? Precio { get; set; }
        public int? IdSector { get; set; }

        public virtual Sector IdSectorNavigation { get; set; }
        public virtual TipoPintura IdTipoPinturaNavigation { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
        public virtual ICollection<Envio> Envio { get; set; }
    }
}
