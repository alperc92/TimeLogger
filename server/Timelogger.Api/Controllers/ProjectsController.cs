using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timelogger.Api.Services;
using Timelogger.Entities;

namespace Timelogger.Api.Controllers
{
	[Route("api/[controller]")]
	public class ProjectsController : Controller
	{
		private readonly IProjectService _projectService;

		public ProjectsController(IProjectService projectService)
		{
			_projectService = projectService;
		}

        #region GET
        [HttpGet]
		[Route("hello-world")]
		public string HelloWorld()
		{
			return "Hello Back!";
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProjects()
		{
			var result = await _projectService.GetAllProjects(); 
			return Ok(result);
		}

		[HttpGet]
		[Route("list/orderbydeadline")]
		public async Task<IActionResult> GetAllProjectsOrderedByDeadline()
		{
			var result = await _projectService.GetAllProjectsOrderedByDeadline();
			return Ok(result);
		}

		[HttpGet]
		[Route("{projectId}")]
		public async Task<IActionResult> GetSingleProject(int projectId)
        {
			var result = await _projectService.GetSingleProject(projectId);
			return Ok(result);
        }		
		#endregion

		#region POST
		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> RegisterProject([FromBody] Project project)
        {
			var result = await _projectService.RegisterProject(project);
			return Ok(result);
        }
		#endregion
	}
}
