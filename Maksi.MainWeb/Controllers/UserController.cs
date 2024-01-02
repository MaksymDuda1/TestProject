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

    public UserController(MaksiDbContext context)
    {
        this.context = context;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var list = context.Users.ToList();
        
        return Ok(list);
    }

    [HttpPost]
    public IActionResult Post([FromBody] User user)
    {
        
        context.Users.Add(user);
        context.SaveChangesAsync();
        
        return Created();
    }
}