using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maksi.MainWeb.Controllers;

[Authorize]
[Route("api/protected")]
public class ProtectedController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        var sidClaim = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Sid);
        Console.WriteLine(sidClaim);

        var id = int.Parse(sidClaim.Value);
        
        var data = $"This is big secret for {id}";

        return Ok(data);
    }
}