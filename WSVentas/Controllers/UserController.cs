﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVentas.Models.Request;
using WSVentas.Models.Response;
using WSVentas.Services;

namespace WSVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar ([FromBody] AuthRequest model)
        {
            Respuesta respuesta = new Respuesta();

            var userResponse = _userService.Auth(model);

            if (userResponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "usuario o contraseña incorrecta";
                return BadRequest(respuesta);
            }

            respuesta.Exito = 1;
            respuesta.Data = userResponse;

            return Ok(respuesta);
        }
    }
}
