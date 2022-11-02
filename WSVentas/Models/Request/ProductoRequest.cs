using System;

namespace WSVentas.Models.Request
{
    public class ProductoRequest
    {
        public int Codigo { get; set; }
        public String Tipo_producto { get; set; }
        public String Descripcion { get; set; }
        public int Id_tipo_pintura { get; set; }
        public int Id_marca { get; set; }
        public int Id_color { get; set; }
        public String Acabado { get; set; }
        public int Tamaño { get; set; }
        public float Precio { get; set; }
        public int Id_sector { get; set; }
    }
}
