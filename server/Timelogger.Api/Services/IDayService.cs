using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Entities;

namespace Timelogger.Api.Services
{
    public interface IDayService
    {
        Task<IEnumerable<Day>> DaysGetAll();
        Task<IEnumerable<Day>> DaysGetSingle(int dayId);
        Task<IEnumerable<Day>> DaysGetAllForWeek(int weekId);
        Task<int> RegisterDay(Day day);
    }
}