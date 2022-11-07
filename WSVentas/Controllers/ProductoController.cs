using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WSVentas.Models.Request;
using WSVentas.Models.Response;
using WSVentas.Models;
using System.Linq;

namespace WSVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public IActionResult getProducto()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    var lst = db.Producto.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]

        public IActionResult AddProducto(ProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    Producto oProducto = new Producto();
                    oProducto.Codigo = oModel.codigo;
                    oProducto.TipoProducto = oModel.tipo_producto;
                    oProducto.Descripcion = oModel.descripcion;
                    oProducto.IdTipoPintura = oModel.id_tipo_pintura;
                    oProducto.IdMarca = oModel.id_marca;
                    oProducto.IdColor = oModel.id_color;
                    oProducto.Acabado = oModel.acabado;
                    oProducto.Tamano = oModel.tamano;
                    oProducto.Precio = oModel.precio;
                    oProducto.IdSector = oModel.id_sector;

                    db.Producto.Add(oProducto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
                Console.WriteLine(ex.InnerException.Message);
            }
            return Ok(oRespuesta);

        }

        [HttpPut]
        public IActionResult editProducto(ProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    Producto oProducto = db.Producto.Find(oModel.codigo);
                    oProducto.TipoProducto = oModel.tipo_producto;
                    oProducto.Descripcion = oModel.descripcion;
                    oProducto.IdTipoPintura = oModel.id_tipo_pintura;
                    oProducto.IdMarca = oModel.id_marca;
                    oProducto.IdColor = oModel.id_color;
                    oProducto.Acabado = oModel.acabado;
                    oProducto.Tamano = oModel.tamano;
                    oProducto.Precio = oModel.precio;
                    oProducto.IdSector = oModel.id_sector;

                    db.Entry(oProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    Producto oProducto = db.Producto.Find(codigo);

                    db.Remove(oProducto);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }


            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }
    }
}

