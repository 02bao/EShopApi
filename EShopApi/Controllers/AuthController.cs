using EShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Username or password is required");
            }
            if (login.name.ToLower() != "kamran" || login.password.ToLower() != "123")
            {
                return Unauthorized();
            }
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("cf83e1357eefb8bdf1542850d66d8007d620e4050b" +
                "5715dc83f4a921d36ce9ce47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e"));
            var signedCretin = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha512);
            var tokenOption =
                new JwtSecurityToken(issuer: "http://localhost:53119",
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.name),
                    new Claim(ClaimTypes.Role, "Admin")
                },
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signedCretin);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);

            return Ok(new {token = tokenString});

        }

    }
}
