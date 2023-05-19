using portfolio_back.Models;

namespace portfolio_back.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> Get();
    Task<Project> Get(int id);
    Task<Project> Create(Project project);
    Task Update(Project project);
    Task Delete(Project project);
}