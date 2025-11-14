using System.ComponentModel.DataAnnotations;

namespace BudMODELS.Models;

public class UserModel
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required, MaxLength(50)]
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string Email { get; set; } = "";
    public string? ProfilePicture { get; set; }

    // Relationer
    public List<WorkoutPost> Posts { get; set; } = new();
    public List<CommentModel> Comments { get; set; } = new();
    public List<Vote> Votes { get; set; } = new();

    // Venner
    // public List<UserFriend> Friends { get; set; } = new();

    // Statistik
    public int TotalWorkouts { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
}
// public class UserFriend
// {
//     public string UserId { get; set; } = "";
//     public UserModel User { get; set; } = null!;
//
//     public string FriendId { get; set; } = "";
//     public UserModel Friend { get; set; } = null!;
// }