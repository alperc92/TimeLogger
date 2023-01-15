using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelogger.Entities;

namespace Timelogger.Persistence
{
    public class WeekRepository: IWeekRepository
    {
        private readonly ApiContext _apiContext;
        public WeekRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        #region GET
        public async Task<IEnumerable<Week>> GetAllWeeks()
        {
            var result = await Task.FromResult(_apiContext.Weeks.Include(d=>d.Days));
            return result;
        }
        public async Task<IEnumerable<Week>> GetAllWeeksByProjectId(int projectId)
        {
            var result = await Task.FromResult(_apiContext.Weeks.Include(d => d.Days).Where(w => w.ProjectId == projectId));
            return result;
        }

        public async Task<Week> GetSingleWeek(int projectId, int weekId)
        {
            var result = await Task.FromResult(_apiContext.Weeks.Include(d => d.Days).FirstOrDefault(w=>w.ProjectId==projectId && w.Id==weekId));
            return result;
        }
        #endregion

        #region POST
        public async Task<int> RegisterWeek(Week week)
        {
            await _apiContext.AddAsync(week);
            return await _apiContext.SaveChangesAsync();
        }
        #endregion
    }
}
