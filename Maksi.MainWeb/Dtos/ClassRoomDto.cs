using System.ComponentModel.DataAnnotations;
using Maksi.Core.Models;

namespace Maksi.MainWeb.Dtos;

public class ClassRoomDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = null!;

    public ClassRoom ToEntity()
    {
        return new ClassRoom()
        {
            Id = Id,
            Name = Name
        };
    }
}