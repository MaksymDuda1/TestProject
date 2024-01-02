namespace Maksi.Core.Models;

public class TimeSlot
{
    public int Id { get; set; }

    public TimeOnly Begin { get; set; }

    public TimeOnly EndTime { get; set; }

    public int DayOfWeek { get; set; }
}