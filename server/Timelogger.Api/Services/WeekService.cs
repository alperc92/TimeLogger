using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Api.DomainServices;
using Timelogger.Entities;
using Timelogger.Persistence;

namespace Timelogger.Api.Services
{
    public class WeekService: IWeekService
    {
        private readonly IWeekRepository _weekRepository;
        private readonly IWeekDomainService _weekDomainService;

        public WeekService(IWeekRepository weekRepository, IWeekDomainService weekDomainService)
        {
            _weekRepository = weekRepository;
            _weekDomainService = weekDomainService;
        }

        #region GET
        public async Task<IEnumerable<Week>> GetAllWeeks()
        {
            var result = await _weekRepository.GetAllWeeks();
            return result;
        }

        public async Task<IEnumerable<Week>> GetAllWeeksByProjectId(int projectId)
        {
            var result = await _weekRepository.GetAllWeeksByProjectId(projectId);
            return result;
        }

        public async Task<Week> GetSingleWeek(int projectId, int weekId)
        {
            var result = await _weekRepository.GetSingleWeek(projectId, weekId);
            return result;
        }
        #endregion

        #region POST
        public async Task<int> RegisterWeek(Week week)
        {
            var validateDeadline = await _weekDomainService.RegisterWeekValidate(week);
            if (!validateDeadline)
                throw new System.Exception("Project deadline is reached and therefore no week can be time-registered on it!");

            return await _weekRepository.RegisterWeek(week);
        }
        #endregion
    }
}
