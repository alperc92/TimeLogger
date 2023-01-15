using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Entities;

namespace Timelogger.Persistence
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<IEnumerable<Project>> GetAllProjectsOrderedByDeadline();
        Task<Project> GetSingleProject(int projectId);
        Task<int> RegisterProject(Project project);
    }
}