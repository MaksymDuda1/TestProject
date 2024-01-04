using System.ComponentModel.DataAnnotations;

namespace Maksi.Core.Models;

public class ClassRoom
{
    public int  Id { get; set; }

    [MaxLength(20)]
    public string Name { get; set; } = null!;
}