using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timelogger.Api.Services;
using Timelogger.Entities;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class DayController: Controller
    {
        private readonly IDayService _dayService;

        public DayController(IDayService dayService)
        {
            _dayService = dayService;
        }

        #region GET
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> DaysGetAll()
        {
            var result = await _dayService.DaysGetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{dayId}")]
        public async Task<IActionResult> DaysGetSingle(int dayId)
        {
            var result = await _dayService.DaysGetSingle(dayId);
            return Ok(result);
        }

        [HttpGet]
        [Route("list/week/{weekId}")]
        public async Task<IActionResult> DaysGetAllForWeek(int weekId)
        {
            var result = await _dayService.DaysGetAllForWeek(weekId);
            return Ok(result);
        }
        #endregion

        #region POST
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterDay(Day day)
        {
            var result = await _dayService.RegisterDay(day);
            return Ok(result);
        }
        #endregion

    }
}
