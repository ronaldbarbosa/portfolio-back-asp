using portfolio_back.Repositories;
using Microsoft.AspNetCore.Mvc;
using portfolio_back.Models;

namespace portfolio_back.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;
    
    public ProjectController(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Project>> GetProjects()
    {
        return await _projectRepository.Get();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProject(int id)
    {
        return await _projectRepository.Get(id);
    }
    
    [HttpPost]
    public async Task<ActionResult<Project>> CreateProject([FromBody] Project project)
    {
        var newProject = await _projectRepository.Create(project);
        return CreatedAtAction(nameof(GetProject), new { id = newProject.Id }, newProject);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProject(int id)
    {
        var projectToDelete = await _projectRepository.Get(id);
        if (projectToDelete == null)
        {
            return NotFound();
        }
        await _projectRepository.Delete(projectToDelete);
        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProject(int id, [FromBody] Project project)
    {
        if (id != project.Id)
        {
            return BadRequest();
        }
        await _projectRepository.Update(project);
        return NoContent();
    }
}