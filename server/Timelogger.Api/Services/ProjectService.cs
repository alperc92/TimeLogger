using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Entities;
using Timelogger.Persistence;

namespace Timelogger.Api.Services
{
    public class ProjectService: IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        #region GET
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            var result = await _projectRepository.GetAllProjects();
            return result;
        }

        public async Task<Project> GetSingleProject(int projectId)
        {
            var result = await _projectRepository.GetSingleProject(projectId);
            return result;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsOrderedByDeadline()
        {
            var result = await _projectRepository.GetAllProjectsOrderedByDeadline();
            return result;
        }
        #endregion

        #region POST
        public async Task<int> RegisterProject(Project project)
        {
            var result = await _projectRepository.RegisterProject(project);
            return result;
        }
        #endregion
    }
}
