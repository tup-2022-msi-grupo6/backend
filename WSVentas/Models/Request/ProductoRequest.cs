using System;

namespace WSVentas.Models.Request
{
    public class ProductoRequest
    {
        public int codigo { get; set; }
        public string tipo_producto { get; set; }
        public string descripcion { get; set; }
        public int id_tipo_pintura { get; set; }
        public int id_marca { get; set; }
        public int id_color { get; set; }
        public string acabado { get; set; }
        public int tamano { get; set; }
        public float precio { get; set; }
        public int id_sector { get; set; }
    }
}