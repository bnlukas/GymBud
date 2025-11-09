namespace BudMODELS.Models;

public class WorkoutPost
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = "";
    public UserModel User { get; set; } = null!;

    public DateTime Created { get; set; } = DateTime.Now;
    public string Caption { get; set; } = "";

    public List<WorkoutEntry> Workouts { get; set; } = new();
    public List<CommentModel> Comments { get; set; } = new();
    public List<Vote> Votes { get; set; } = new();

    public int Upvotes { get; set; } = 0;
    public int Downvotes { get; set; } = 0;
}
