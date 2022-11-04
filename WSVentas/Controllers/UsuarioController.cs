using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentas.Models;
using WSVentas.Models.Response;
using WSVentas.Models.Request;


namespace WSVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {

            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;

            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    var lst = db.Usuario.OrderByDescending(d => d.IdUsuario).ToList();
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
        public IActionResult Add(UsuarioRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    Usuario oUsuario = new Usuario();
                    oUsuario.Email = oModel.email;
                    oUsuario.Password = oModel.password;
                    oUsuario.Nombre = oModel.nombre;
                    oUsuario.IdRol = oModel.id_rol;
                    db.Usuario.Add(oUsuario);
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
        public IActionResult Edit(UsuarioRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    Usuario oUsuario = db.Usuario.Find(oModel.idUsuario);
                    oUsuario.Email = oModel.email;
                    oUsuario.Password = oModel.password;
                    oUsuario.Nombre = oModel.nombre;
                    oUsuario.IdRol = oModel.id_rol;
                    db.Entry(oUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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


        [HttpDelete("{idUsuario}")]
        public IActionResult Delete(int idUsuario)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    Usuario oUsuario = db.Usuario.Find(idUsuario);
                    db.Remove(oUsuario);
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
