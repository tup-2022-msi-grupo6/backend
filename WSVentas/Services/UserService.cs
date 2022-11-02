using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WSVentas.Models;
using WSVentas.Models.Common;
using WSVentas.Models.Request;
using WSVentas.Models.Response;
using WSVentas.tools;

namespace WSVentas.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        public UserService (IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse();

            using (var db = new VentaRealContext())
            {
                string sPassword = Encrypt.GetSHA256(model.Password);

                var usuario = db.Usuario.Where(d => d.Email == model.Email &&
                d.Password == sPassword).FirstOrDefault();

                if (usuario == null) return null;

                userResponse.Email = usuario.Email;
                userResponse.Token = getToken(usuario);
            }
            return userResponse;
        }


        private string getToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                            new Claim(ClaimTypes.Email, usuario.Email)
                        }
                ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
