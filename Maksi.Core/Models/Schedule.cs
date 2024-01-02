namespace Maksi.Core.Models;

public class Schedule
{
    public int Id { get; set; }

    public int ClassRoomId { get; set; }

    public ClassRoom ClassRoom { get; set; } = null!;
    
    public int SubjectId { get; set; }

    public Subject Subject { get; set; } = null!;
    
    public int GradeId { get; set; }

    public Grade Grade { get; set; } = null!;
    
    public int TimeSlotId { get; set; }

    public TimeSlot TimeSlot { get; set; } = null!;
}