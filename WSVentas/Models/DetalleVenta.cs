using System;
using System.Collections.Generic;

namespace WSVentas.Models
{
    public partial class DetalleVenta
    {
        public int NroFac { get; set; }
        public int CodigoProducto { get; set; }
        public int? Cantidad { get; set; }
        public string Descripcion { get; set; }
        public double? PrecioUnitario { get; set; }
        public double? ImporteBruto { get; set; }
        public double? Descuento { get; set; }
        public double? Impuesto { get; set; }
        public double? Total { get; set; }

        public virtual Producto CodigoProductoNavigation { get; set; }
        public virtual Venta NroFacNavigation { get; set; }
    }
}
