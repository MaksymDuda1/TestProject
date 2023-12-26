using Maksi.Core;
using Maksi.Core.Models;
using Maksi.MainWeb.Dtos;
using Maksi.MainWeb.EntityExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maksi.MainWeb.Controllers;

[Route("api/register")]
public class RegisterController: Controller
{

    private MaksiDbContext context;
    
    public RegisterController(MaksiDbContext dbContext )
    {
        this.context = dbContext;
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserDto user)
    {
        var isRegistered =  context.Users.Any(u => u.Email == user.Email);

        if (isRegistered)
        {
            return BadRequest($"User already exists");
        }

        var entity = user.ToEntity();
        
        context.Users.Add(entity);
        context.SaveChangesAsync();

        return Created("", entity.ToDto());
    }
}