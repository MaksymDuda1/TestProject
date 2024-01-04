using Maksi.Core;
using Maksi.MainWeb.Dtos;
using Maksi.MainWeb.EntityExtensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Maksi.MainWeb.Controllers;

[Route("api/class-room")]
public class ClassRoomController : Controller
{
    private readonly MaksiDbContext context;

    public ClassRoomController(MaksiDbContext context)
    {
        this.context = context;
    }
    
    [HttpGet]
    public IActionResult List()
    {
        var list = context.ClassRooms.ToList();
        var result = list.Select(item => item.ToDto());
        
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult Detail(int id)
    {
        var entity = context.ClassRooms.SingleOrDefault(p => p.Id == id);

        Console.WriteLine(id);
        
        if (entity == null)
        {
            return NotFound($"Class room with id: {id} doesn't exist");
        }

        var dto = entity.ToDto();

        return Ok(dto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ClassRoomDto data)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest($"{nameof(ClassRoomDto)} isn't valid");
        }

        var entity = data.ToEntity();

        context.ClassRooms.Add(entity);
        context.SaveChanges();

        var dto = entity.ToDto();

        return Created($"/api/class-room/{dto.Id}", dto);
    }



    [HttpPut]
    public IActionResult Update([FromBody] ClassRoomDto data)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest($"{nameof(ClassRoomDto)} isn't valid");
        }


        var entity = context.ClassRooms.SingleOrDefault(p => p.Id == data.Id);

        if (entity == null)
        {
            return NotFound($"Class room with id: {data.Id} doesn't exist");
        }

        entity.Name = data.Name;

        var dto = entity.ToDto();
        context.SaveChanges();
        
        return Ok(dto);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var entity = context.ClassRooms.SingleOrDefault(p => p.Id == id);

        if (entity != null)
        {
            context.ClassRooms.Remove(entity);
            context.SaveChanges();
        }

        return Ok();
    }
    
    /*private IActionResult ReturnBadRequestWithErrors()
    {
        var errors = new List<string>();

        foreach (var state in ModelState)
        {
            errors.AddRange(
                state.Value.Errors.Select(p => p.ErrorMessage));
        }

        return  BadRequest(new { errorList = errors });
    }*/



}