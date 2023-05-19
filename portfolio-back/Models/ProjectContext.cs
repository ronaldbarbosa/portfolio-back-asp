using Microsoft.EntityFrameworkCore;

namespace portfolio_back.Models;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    // Para cada entidade criar um DbSet
    public DbSet<Project> Projects { get; set; }
}