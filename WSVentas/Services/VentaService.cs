using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentas.Models;
using WSVentas.Models.Request;

namespace WSVentas.Services
{
    public class VentaService : IVentaService
    {
        public void Add(VentaRequest model)
        {
                using (PintucorContext db = new PintucorContext())
                {

                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var venta = new Venta();
                            venta.DetalleVenta.Total = model.Detalle_Venta.Sum(d => d.Cantidad * d.Precio_Unitario);
                            venta.FechaVenta = DateTime.Now;
                            venta.IdCliente = model.Id_cliente;
                            db.Venta.Add(venta);
                            db.SaveChanges();

                            foreach (var modelDetalle_venta in model.Detalle_Venta)
                            {
                                var detalle_venta = new Models.DetalleVenta();
                                detalle_venta.Cantidad = modelDetalle_venta.Cantidad;
                                detalle_venta.CodigoProducto = modelDetalle_venta.Codigo_Producto;
                                detalle_venta.PrecioUnitario = modelDetalle_venta.Precio_Unitario;
                                detalle_venta.ImporteBruto = modelDetalle_venta.Importe_Bruto;
                                detalle_venta.NroFac = venta.NroFac;
                                db.DetalleVenta.Add(detalle_venta);
                                db.SaveChanges();
                            }

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw new Exception("Ocurrio un error en la insercion");
                        }
                    }
                }            
        }
    }
}
