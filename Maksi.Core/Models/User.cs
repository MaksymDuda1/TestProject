namespace Maksi.Core.Models;

public class User
{
    public int  Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

}