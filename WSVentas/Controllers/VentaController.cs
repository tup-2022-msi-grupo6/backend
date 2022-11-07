using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WSVentas.Models;
using WSVentas.Models.Request;
using WSVentas.Models.Response;
using WSVentas.Services;
using WSVentas.Tools;

namespace WSVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private IVentaService _venta;

        public VentaController(IVentaService venta) 
        {
            this._venta = venta;
        }

        [HttpPost]
        public IActionResult Add(VentaRequest model)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                _venta.Add(model);
                respuesta.Exito = 1;
            }
            catch(Exception ex)
            {
                respuesta.Mensaje = ex.InnerException.ToString();   
            }

            return Ok(respuesta);
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    var lst = db.Venta.OrderByDescending(d => d.NroFac).ToList();
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

        [HttpDelete("{NroFac}")]
        public IActionResult Delete(int NroFac)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    DetalleVenta oDVenta = db.DetalleVenta.Find(NroFac);
                    db.Remove(oDVenta);
                    db.SaveChanges();

                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
                //oRespuesta.Mensaje = ex.InnerException.ToString();
            }

            return Ok(oRespuesta);
        }
    }
}
