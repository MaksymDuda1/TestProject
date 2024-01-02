namespace Maksi.Core.Models;

public class User
{
    public int  Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public List<UserRole> UserRoles { get; set; }                                                      

    public int? GradeId { get; set; }

    public Grade? Grade { get; set; }

}