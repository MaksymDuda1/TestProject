using AutoMapper;
using Maksi.Core;
using Maksi.Core.Models;
using Maksi.MainWeb.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maksi.MainWeb.Controllers;

[Route("api/user")]
public class UserController : Controller
{
    private readonly MaksiDbContext context;
    private readonly IMapper mapper;

    public UserController(MaksiDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var list = context.Users.ToList();
        
        return Ok(list);
    }

    [HttpPost]
    public IActionResult Post([FromBody] UserDto user)
    {
        var entity = mapper.Map<User>(user);
        context.Users.Add(entity);
        context.SaveChangesAsync();
        
        return Created();
    }
}