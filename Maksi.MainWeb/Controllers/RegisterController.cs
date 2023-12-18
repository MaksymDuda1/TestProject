using Maksi.Core;
using Maksi.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maksi.MainWeb.Controllers;

public class RegisterController: Controller
{
    private MaksiDbContext context;
    
    public RegisterController(MaksiDbContext dbContext )
    {
        this.context = context;
    }

    public async Task<IActionResult> Post([FromBody] User user)
    {
        User userToAdd = await context.Users.FirstOrDefaultAsync(u => user.Email == u.Email);

        if (userToAdd != null)
        {
            return Conflict($"User already exists");
        }

        context.Users.Add(user);

        context.SaveChangesAsync();

        return Created("", user);
    }
}