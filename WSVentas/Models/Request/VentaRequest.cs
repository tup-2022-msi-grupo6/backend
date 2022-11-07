using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSVentas.Models.Request
{
    public class VentaRequest
    {
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage ="Valor de id cliente debe ser mayor a 0")]
        [ExisteCliente(ErrorMessage ="El cliente no existe")]
        public int Id_cliente { get; set; }

        [Required]
        [MinLength(1, ErrorMessage ="Debe existir detalle venta")]
        public List<Detalle_Venta> Detalle_Venta { get; set; }

        public VentaRequest ()
        {
            this.Detalle_Venta = new List<Detalle_Venta>();
        }
    }

    public class Detalle_Venta
    {
        public int NroFac { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Importe_Bruto { get; set; }
        public int Codigo_Producto { get; set; }
    }


    #region Validaciones
    public class ExisteClienteAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int Id_cliente = (int)value;
            using (var db = new Models.PintucorContext())
            {
                if (db.Cliente.Find(Id_cliente) == null)
                {
                    return false;
                }
            }
            return true;
        }
    }

    
    #endregion
}
