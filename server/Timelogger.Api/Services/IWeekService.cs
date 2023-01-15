using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Entities;

namespace Timelogger.Api.Services
{
    public interface IWeekService
    {
        Task<IEnumerable<Week>> GetAllWeeks();
        Task<IEnumerable<Week>> GetAllWeeksByProjectId(int projectId);
        Task<Week> GetSingleWeek(int projectId, int weekId);
        Task<int> RegisterWeek(Week week);
    }
}