using System;
using System.Threading.Tasks;
using Timelogger.Entities;
using Timelogger.Persistence;

namespace Timelogger.Api.DomainServices
{
    public class WeekDomainService: IWeekDomainService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IWeekRepository _weekRepository;

        public WeekDomainService(IProjectRepository projectRepository, IWeekRepository weekRepository)
        {
            _projectRepository = projectRepository;
            _weekRepository = weekRepository;
        }

        public async Task<bool> RegisterWeekValidate(Week week)
        {
            var project = await _projectRepository.GetSingleProject(week.ProjectId);
            if ((project==null) || project.Deadline <= DateTime.Now)
                return false;

            return true;
        }
    }
}
