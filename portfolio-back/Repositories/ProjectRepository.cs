using Microsoft.EntityFrameworkCore;
using portfolio_back.Models;

namespace portfolio_back.Repositories;

public class ProjectRepository : IProjectRepository
{
    public readonly ProjectContext _context;
    
    public ProjectRepository(ProjectContext projectContext)
    {
        _context = projectContext;
    }
    
    public async Task<IEnumerable<Project>> Get()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project> Get(int id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task<Project> Create(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task Update(Project project)
    {
        _context.Entry(project).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Project project)
    {
        var projectToDelete = await _context.Projects.FindAsync(project.Id);
        _context.Projects.Remove(projectToDelete);
        await _context.SaveChangesAsync();
    }
}