using AutoMapper;
using Maksi.Core;
using Maksi.Core.Models;
using Maksi.MainWeb.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maksi.MainWeb.Controllers;

[Route("api/register")]
public class RegisterController: Controller
{

    private readonly IMapper mapper;
    private MaksiDbContext context;
    
    public RegisterController(MaksiDbContext dbContext, IMapper mapper )
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task<IActionResult> Post([FromBody] UserDto user)
    {
        User userToAdd = await context.Users.FirstOrDefaultAsync(u => user.Email == u.Email);

        if (userToAdd != null)
        {
            Console.WriteLine("Hello");
            return Conflict($"User already exists");
        }

        var entity = mapper.Map<User>(user);
        context.Users.Add(entity);

        context.SaveChangesAsync();

        return Created("", entity);
    }
}