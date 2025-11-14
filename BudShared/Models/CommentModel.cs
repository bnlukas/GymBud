using System.ComponentModel.DataAnnotations;

namespace BudMODELS.Models;

public class CommentModel
{
    [Key]
    private string Id { get; set;  } = Guid.NewGuid().ToString();
    public string Content { get; set; } = ""; 
    public DateTime Created { get; set; } = DateTime.Now;


    public string UserId { get; set; } = ""; 
    public UserModel User { get; set; } = null!;
    
    public string WorkoutPostId { get; set; } = "";
    public WorkoutPost WorkoutPost { get; set; } = null!;
    
}