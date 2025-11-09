namespace BudMODELS.Models;

public class WorkoutEntry
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string WorkoutPostId { get; set; } = "";
    public WorkoutPost WorkoutPost { get; set; } = null!;

    public string MuscleGroup { get; set; } = "";
    public string Exercise { get; set; } = "";
    public int Sets { get; set; }
    public int Reps { get; set; }
    public double WeightKg { get; set; }
}
