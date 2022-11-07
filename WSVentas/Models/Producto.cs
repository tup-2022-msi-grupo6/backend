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
        public string? TipoProducto { get; set; }
        public string? Descripcion { get; set; }
        public int? IdTipoPintura { get; set; }
        public int? IdMarca { get; set; }
        public int? IdColor { get; set; }
        public string Acabado { get; set; }
        public int? Tamano { get; set; }
        public double? Precio { get; set; }
        public int? IdSector { get; set; }

        public virtual Color IdColorNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual Sector IdSectorNavigation { get; set; }
        public virtual TipoPintura IdTipoPinturaNavigation { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
        public virtual ICollection<Envio> Envio { get; set; }
    }
}