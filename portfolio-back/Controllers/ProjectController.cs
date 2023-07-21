using portfolio_back.Repositories;
using Microsoft.AspNetCore.Mvc;
using portfolio_back.Models;
using portfolio_back.Attributes;
using Microsoft.Extensions.Caching.Memory;

namespace portfolio_back.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMemoryCache _memoryCache;
    private const string PROJECTS_KEY = "Projects";
    
    public ProjectController(IProjectRepository projectRepository, IMemoryCache memoryCache)
    {
        _projectRepository = projectRepository;
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public async Task<IEnumerable<Project>> GetProjects()
    {
        if(_memoryCache.TryGetValue(PROJECTS_KEY, out IEnumerable<Project> projects))
        {
            return projects;
        }

        projects = await _projectRepository.Get();
        _memoryCache.Set(PROJECTS_KEY, projects);

        return projects;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProject(Guid id)
    {
        return await _projectRepository.Get(id);
    }

    [ApiKeyAtribute]
    [HttpPost]
    public async Task<ActionResult<Project>> CreateProject([FromBody] Project project)
    {
        var newProject = await _projectRepository.Create(project);
        newProject.Id = Guid.NewGuid();
        return CreatedAtAction(nameof(GetProject), new { id = newProject.Id }, newProject);
    }

    [ApiKeyAtribute]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProject(Guid id)
    {
        var projectToDelete = await _projectRepository.Get(id);
        if (projectToDelete == null)
        {
            return NotFound();
        }
        await _projectRepository.Delete(projectToDelete);
        return NoContent();
    }

    [ApiKeyAtribute]
    [HttpPut]
    public async Task<ActionResult> UpdateProject(Guid id, [FromBody] Project project)
    {
        await _projectRepository.Update(project);
        return NoContent();
    }
}