using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Maksi.Core;
using Maksi.Core.Models;
using Maksi.MainWeb.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Maksi.MainWeb.Controllers;

[Route("api/Login")]
public class LoginController : Controller
{
    private readonly MaksiDbContext context;
    private readonly IConfiguration configuration;

    public LoginController(MaksiDbContext context, IConfiguration configuration)
    {
        this.context = context;
        this.configuration = configuration;
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserDto user)
    {
        var entity = user.ToEntity();

        var userDB = context.Users.FirstOrDefaultAsync(u => u.Email == entity.Email
                                                            && user.Password == entity.Password);

        if (entity == null)
        {
            return BadRequest("User name or password are incorrect");
        }

        var token = CreateToken(entity);

        return Ok(token);
    }

    private string CreateToken(User entity)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.Sid, entity.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.Email, entity.Email));

        var identity = new ClaimsIdentity(claims);

        var jwtSecret = configuration["JwtSecret"]!;

        var key = Encoding.ASCII.GetBytes(jwtSecret);
        
        var tokenDescription = new SecurityTokenDescriptor()
        {
            Subject = identity,
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescription);

        return tokenHandler.WriteToken(token);
    }
}