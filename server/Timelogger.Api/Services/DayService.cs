using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Entities;
using Timelogger.Persistence;

namespace Timelogger.Api.Services
{
    public class DayService: IDayService
    {
        private readonly IDayRepository _dayRepository;

        public DayService(IDayRepository dayRepository)
        {
            _dayRepository = dayRepository;
        }

        #region GET
        public async Task<IEnumerable<Day>> DaysGetAll()
        {
            var result = await _dayRepository.DaysGetAll();
            return result;
        }

        public async Task<IEnumerable<Day>> DaysGetSingle(int dayId)
        {
            var result = await _dayRepository.DaysGetSingle(dayId);
            return result;
        }

        public async Task<IEnumerable<Day>> DaysGetAllForWeek(int weekId)
        {
            var result = await _dayRepository.DaysGetAllForWeek(weekId);
            return result;
        }
        #endregion

        #region POST
        public async Task<int> RegisterDay(Day day)
        {
            return await _dayRepository.RegisterDay(day);
        }
        #endregion
    }
}
