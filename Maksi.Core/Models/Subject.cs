using System.ComponentModel.DataAnnotations;

namespace Maksi.Core.Models;

public class Subject
{
    public int Id { get; set; }

    [MaxLength(20)]
    public string Name { get; set; } = null!;

}