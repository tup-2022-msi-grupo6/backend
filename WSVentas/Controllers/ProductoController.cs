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

        public IActionResult addProducto(ProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    Producto oProducto = new Producto();
                    oProducto.TipoProducto = oModel.Tipo_producto;
                    oProducto.Descripcion = oModel.Descripcion;
                    oProducto.IdTipoPintura = oModel.Id_tipo_pintura;
                    oProducto.IdMarca = oModel.Id_marca;
                    oProducto.IdColor = oModel.Id_color;
                    oProducto.Acabado = oModel.Acabado;
                    oProducto.Tamaño = oModel.Tamaño;
                    oProducto.Precio = oModel.Precio;
                    oProducto.IdSector = oModel.Id_sector;

                    db.Producto.Add(oProducto);
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

        [HttpPut]
        public IActionResult editProducto(ProductoRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    Producto oProducto = db.Producto.Find(oModel.Codigo);
                    oProducto.TipoProducto = oModel.Tipo_producto;
                    oProducto.Descripcion = oModel.Descripcion;
                    oProducto.IdTipoPintura = oModel.Id_tipo_pintura;
                    oProducto.IdMarca = oModel.Id_marca;
                    oProducto.IdColor = oModel.Id_color;
                    oProducto.Acabado = oModel.Acabado;
                    oProducto.Tamaño = oModel.Tamaño;
                    oProducto.Precio = oModel.Precio;
                    oProducto.IdSector = oModel.Id_sector;

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

        [HttpDelete]
        public IActionResult deleteProducto(int Codigo)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    Producto oProducto = db.Producto.Find(Codigo);

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
    
