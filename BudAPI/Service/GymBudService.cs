using BudAPI.Data;
using BudMODELS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Net.Http.Headers;

namespace BudAPI.Service;

public class GymBudService
{
    private readonly GymContext _db;

    public GymBudService(GymContext db)
    {
        _db = db; 
    }

    public async Task<List<WorkoutPost>> GetAllPostsAsync()
    {
        return await _db.WorkoutPosts
            .Include(p => p.Comments)
            .ThenInclude(c => c.User)
            .Include(p => p.Workouts)
            .Include(p => p.User)
            .OrderByDescending(p => p.Created)
            .Take(50)
            .ToListAsync();
    }
}