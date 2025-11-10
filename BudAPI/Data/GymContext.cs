using Microsoft.EntityFrameworkCore;
using BudMODELS.Models;

namespace BudAPI.Data;

public class GymContext : DbContext
{
    public string DbPath { get; }

    public GymContext()
    {
        var folder = AppContext.BaseDirectory;
        DbPath = Path.Combine(folder, "gymbud.db");
        Console.WriteLine($"Database path: {DbPath}");
    }

    public GymContext(DbContextOptions<GymContext> options)
        : base(options)
    {
        var folder = AppContext.BaseDirectory;
        DbPath = Path.Combine(folder, "gymbud.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }

    // ----- DbSets -----
    public DbSet<UserModel> Users { get; set; } = null!;
    public DbSet<WorkoutPost> WorkoutPosts { get; set; } = null!;
    public DbSet<WorkoutEntry> WorkoutEntries { get; set; } = null!;
    public DbSet<CommentModel> Comments { get; set; } = null!;
    public DbSet<Vote> Votes { get; set; } = null!;
    

    // ----- Relationer -----
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User -> Posts
        modelBuilder.Entity<WorkoutPost>()
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // User -> Comments
        modelBuilder.Entity<CommentModel>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Post -> Comments
        modelBuilder.Entity<CommentModel>()
            .HasOne(c => c.WorkoutPost)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.WorkoutPostId)
            .OnDelete(DeleteBehavior.Cascade);

        // Post -> WorkoutEntries
        modelBuilder.Entity<WorkoutEntry>()
            .HasOne(e => e.WorkoutPost)
            .WithMany(p => p.Workouts)
            .HasForeignKey(e => e.WorkoutPostId)
            .OnDelete(DeleteBehavior.Cascade);

        // Votes (User + Post)
        modelBuilder.Entity<Vote>()
            .HasOne(v => v.User)
            .WithMany(p => p.Votes)
            .HasForeignKey(v => v.UserId);

        modelBuilder.Entity<Vote>()
            .HasOne(v => v.WorkoutPost)
            .WithMany(p => p.Votes)
            .HasForeignKey(v => v.WorkoutPostId);

        base.OnModelCreating(modelBuilder);
    }
}