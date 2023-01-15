using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelogger.Entities;

namespace Timelogger.Persistence
{
    public class DayRepository: IDayRepository
    {
        private readonly ApiContext _apiContext;

        public DayRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        #region GET
        public async Task<IEnumerable<Day>> DaysGetAll()
        {
            var result = await Task.FromResult(_apiContext.Days);
            return result;
        }

        public async Task<IEnumerable<Day>> DaysGetSingle(int dayId)
        {
            var result = await Task.FromResult(_apiContext.Days.Where(d=>d.Id == dayId));
            return result;
        }

        public async Task<IEnumerable<Day>> DaysGetAllForWeek(int weekId)
        {
            var result = await Task.FromResult(_apiContext.Days.Where(d => d.WeekId == weekId));
            return result;
        }
        #endregion

        #region POST

        public async Task<int> RegisterDay(Day day)
        {
            _= await _apiContext.Days.AddAsync(day);
            var result = await _apiContext.SaveChangesAsync();
            return result;
        }
        #endregion

    }
}
