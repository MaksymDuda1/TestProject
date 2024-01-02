using Maksi.Core;
using Maksi.Core.Models;
using Maksi.MainWeb.Dtos;
using Maksi.MainWeb.EntityExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Maksi.MainWeb.Controllers;

[Route("api/grade")]
public class GradeController : Controller
{
    private readonly MaksiDbContext context;

    public GradeController(MaksiDbContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var list = context.Grades.ToList();

        var result = list.Select(p => p.ToDto());

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult Detail(int id)
    {
        var entity = context.Grades.SingleOrDefault(p => p.Id == id);

        if (entity == null)
        {
            return NotFound("Cannot found Grade with this id");
        }

        return Ok(entity);
    }

    [HttpPost]
    public IActionResult Post([FromBody] GradeDto grade)
    {
        var entity = grade.ToEntity();

        context.Add(entity);
        context.SaveChanges();

        return Created($"/api/grade/{grade.Id}", grade);
    }

    [HttpPut]
    public IActionResult Update([FromBody] GradeDto gradeDto)
    {
        var entity = context.Grades.SingleOrDefault(p => p.Id == gradeDto.Id);

        if (entity == null)
        {
            return NotFound("Not found");
        }

        entity.Name = gradeDto.Name;

        var dto = entity.ToDto();
        context.SaveChanges();

        return Ok(dto);


    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var entity = context.Grades.SingleOrDefault(p => p.Id == id);

        if (entity == null)
        {
            return BadRequest("Not found");
        }

        context.Remove(entity);
        context.SaveChanges();
        
        return Ok();
    }

}