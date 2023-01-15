using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Entities;

namespace Timelogger.Api.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<IEnumerable<Project>> GetAllProjectsOrderedByDeadline();
        Task<Project> GetSingleProject(int projectId);
        Task<int> RegisterProject(Project project);
    }
}