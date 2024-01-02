namespace Maksi.Core.Models;

public class TeacherOfSubject
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;
    
    public int SubjectId { get; set; }

    public Subject Subject { get; set; } = null!;


}