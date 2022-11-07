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
        public decimal? PrecioUnitario { get; set; }
        public decimal? ImporteBruto { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Impuesto { get; set; }
        public decimal? Total { get; set; }

        public virtual Producto CodigoProductoNavigation { get; set; }
        public virtual Venta NroFacNavigation { get; set; }
    }
}
