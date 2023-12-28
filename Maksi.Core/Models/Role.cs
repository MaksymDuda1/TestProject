using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Maksi.Core.Models;

public class Role
{
    public int Id { get; set; }
    
    [MaxLength(100)] 
    public string Name { get; set; } = null!;
}