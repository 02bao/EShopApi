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
            if (login.name.ToLower() != "Kamran" || login.password.ToLower() != "123")
            {
                return Unauthorized();
            }
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OurFirst.NetCore3RestApiForTestWithJwt"));
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
