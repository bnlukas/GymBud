namespace BudMODELS.Models;

public class WorkoutStats
{
    public string UserId { get; set; } = ""; 
    public int WeekCount { get; set; }
    public int MonthCount { get; set; }
    public int YearCount { get; set; }
    
    public Dictionary<string, int> MuscleGroups { get; set; } = new();
    
}