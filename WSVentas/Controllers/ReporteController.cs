using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentas.Models;
using WSVentas.Models.Response;
using Microsoft.AspNetCore.Authorization;
using WSVentas.Models.Response.ReportesResponse;
using Microsoft.EntityFrameworkCore;

namespace WSVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReporteController : Controller
    {

        [HttpPost]
        [Route("ventas/cantidades")]
        public IActionResult GetTotales([FromBody] DiaMesAnio fecha)
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            DiaMesAnio cantidades = new DiaMesAnio();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    var cantidadDia = db.Venta.Where(v => v.FechaVenta.Value.Day.Equals(fecha.Dia) && v.FechaVenta.Value.Month.Equals(fecha.Mes) && v.FechaVenta.Value.Year.Equals(fecha.Anio))
                        .Count();
                    var cantidadMes = db.Venta.Where(v => v.FechaVenta.Value.Month.Equals(fecha.Mes) && v.FechaVenta.Value.Year.Equals(fecha.Anio))
                        .Count();
                    var cantidadAnio = db.Venta.Where(v => v.FechaVenta.Value.Year.Equals(fecha.Anio))
                        .Count();

                    cantidades.Dia = cantidadDia;
                    cantidades.Mes = cantidadMes;
                    cantidades.Anio = cantidadAnio;

                    oRespuesta.Exito = 1;
                    oRespuesta.Data = cantidades;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpPost]
        [Route("ventas/ingresos")]
        public IActionResult GetTotalesIngresos([FromBody] DiaMesAnio fecha)
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            DiaMesAnioIngreso ingresos = new DiaMesAnioIngreso();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    var cantidadDia = db.DetalleVenta.Join(db.Venta, dv => dv.NroFac, v => v.NroFac, (dv, v) => new { dv, v })
                        .Where(x => x.v.FechaVenta.Value.Day.Equals(fecha.Dia) && x.v.FechaVenta.Value.Month.Equals(fecha.Mes) && x.v.FechaVenta.Value.Year.Equals(fecha.Anio))
                        .Sum(x => x.dv.Total);
                    var cantidadMes = db.DetalleVenta.Join(db.Venta, dv => dv.NroFac, v => v.NroFac, (dv, v) => new { dv, v })
                        .Where(x => x.v.FechaVenta.Value.Month.Equals(fecha.Mes) && x.v.FechaVenta.Value.Year.Equals(fecha.Anio))
                        .Sum(x => x.dv.Total);
                    var cantidadAnio = db.DetalleVenta.Join(db.Venta, dv => dv.NroFac, v => v.NroFac, (dv, v) => new { dv, v })
                        .Where(x =>  x.v.FechaVenta.Value.Year.Equals(fecha.Anio))
                        .Sum(x => x.dv.Total);

                    ingresos.Dia = (double)cantidadDia;
                    ingresos.Mes = (double)cantidadMes;
                    ingresos.Anio = (double)cantidadAnio;

                    oRespuesta.Exito = 1;
                    oRespuesta.Data = ingresos;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        [Route("ventas/ingresosxmeses")]
        public IActionResult GetIngresosXmeses([FromBody] DiaMesAnio fecha)
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            MesIngreso ingresos = new MesIngreso();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {
                    
                    var lst = db.DetalleVenta.Join(db.Venta, dv => dv.NroFac, v => v.NroFac, (dv, v) => new { dv, v })
                        .Where(x => x.v.FechaVenta.Value.Year.Equals(fecha.Anio)).GroupBy(x => x.v.FechaVenta.Value.Month)
                        .Select(y => new {Mes = y.Key,Ingreso = y.Sum(x => x.dv.Total)})
                        .ToList();

                    foreach (var item in lst)
                    {
                        ingresos.Mes = item.Mes;
                        ingresos.Ingreso = (double)item.Ingreso;
                    }
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
        [Route("ventas/ingresoanualxempleado")]
        public IActionResult GetIngresosAXempleados([FromBody] DiaMesAnio fecha)
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            EmpleadoIngreso ingresos = new EmpleadoIngreso();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {

                    var lst = db.Venta
                            .Join(db.DetalleVenta, v => v.NroFac, dv => dv.NroFac, (v, dv) => new { v, dv })
                            .Where(x => x.v.FechaVenta.Value.Year.Equals(fecha.Anio))
                            .Join(db.Empleado, vv => vv.v.IdEmpleado, e => e.IdEmpleado, (vv, e) => new { vv, e })
                            .GroupBy(x => x.e.Apellido)
                            .Select(y => new
                            {
                                Empleado = y.Key,
                                Total = y.Sum(x => x.vv.dv.Total)
                            })
                            .Take(4)
                            .ToList();

                    foreach (var item in lst)
                    {
                        ingresos.Empleado = item.Empleado;
                        ingresos.Total = (double)item.Total;
                    }
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
        [Route("ventas/ingresomensualxempleado")]
        public IActionResult GetIngresosMXempleados([FromBody] DiaMesAnio fecha)
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            EmpleadoIngreso ingresos = new EmpleadoIngreso();
            try
            {
                using (PintucorContext db = new PintucorContext())
                {

                    var lst = db.Venta
                            .Join(db.DetalleVenta, v => v.NroFac, dv => dv.NroFac, (v, dv) => new { v, dv })
                            .Where(x => x.v.FechaVenta.Value.Year.Equals(fecha.Anio) && x.v.FechaVenta.Value.Month.Equals(fecha.Mes))
                            .Join(db.Empleado, vv => vv.v.IdEmpleado, e => e.IdEmpleado, (vv, e) => new { vv, e })
                            .GroupBy(x => x.e.Apellido)
                            .Select(y => new
                            {
                                Empleado = y.Key,
                                Total = y.Sum(x => x.vv.dv.Total)
                            })
                            .Take(4)
                            .ToList();

                    foreach (var item in lst)
                    {
                        ingresos.Empleado = item.Empleado;
                        ingresos.Total = (double)item.Total;
                    }
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


    }
}
