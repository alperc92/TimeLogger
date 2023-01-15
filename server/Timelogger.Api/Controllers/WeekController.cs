using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Api.Services;
using Timelogger.Entities;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class WeekController: Controller
    {
        private readonly IWeekService _weekService;

        public WeekController(IWeekService weekService)
        {
            _weekService = weekService;
        }

        #region GET
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllWeeks()
        {
            var result = await _weekService.GetAllWeeks();
            return Ok(result);
        }

        [HttpGet]
        [Route("list/project/{projectId}")]
        public async Task<IActionResult> GetAllWeeksByProjectId(int projectId)
        {
            var result = await _weekService.GetAllWeeksByProjectId(projectId);
            return Ok(result);
        }

        [HttpGet]
        [Route("single/project/{projectId}/week/{weekId}")]
        public async Task<IActionResult> GetSingleWeek(int projectId, int weekId)
        {
            var result = await _weekService.GetSingleWeek(projectId, weekId);
            return Ok(result);
        }
        #endregion

        #region POST
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterWeek([FromBody] Week week)
        {
            var result = 0;
            try
            {
                result = await _weekService.RegisterWeek(week);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok(result);
        }
        #endregion
    }
}
