using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Entities;

namespace Timelogger.Persistence
{
    public interface IDayRepository
    {
        Task<IEnumerable<Day>> DaysGetAll();
        Task<IEnumerable<Day>> DaysGetSingle(int dayId);
        Task<IEnumerable<Day>> DaysGetAllForWeek(int weekId);
        Task<int> RegisterDay(Day day);
    }
}