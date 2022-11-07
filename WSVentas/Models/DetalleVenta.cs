using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WSVentas.Tools;

namespace WSVentas.Models
{
    public partial class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int NroFac { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal ImporteBruto { get; set; }
        public double? Descuento { get; set; }
        public double? Impuesto { get; set; }

        public virtual Producto CodigoProductoNavigation { get; set; }
        public virtual Venta NroFacNavigation { get; set; }
    }
}
