namespace BudMODELS.Models;

public class Vote
{
    public string Id { get; set; } =  Guid.NewGuid().ToString();
    public string UserId { get; set; } = "";
    public UserModel User { get; set; } = null!;
    
    public string WorkoutPostId { get; set; } = "";
    public WorkoutPost WorkoutPost { get; set; } = null!;
    
    public bool IsUpvoted { get; set; } = false;
    
}