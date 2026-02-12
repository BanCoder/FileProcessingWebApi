using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using DataAccess.Model;
namespace TestTaskWeb.Controllers
{
	[ApiController]
	[Route("api/results")]
	public class ResultController : ControllerBase
	{
		private readonly IResultService _resultService; 
		public ResultController(IResultService resultService)
		{
			_resultService = resultService;
		}
		[HttpGet("filtered")]
		public async Task<IActionResult> GetFiltredResults([FromQuery] FilteredDto filtered)
		{
			var results = await _resultService.GetFiltredFilesAsync(filtered); 
			return Ok(results);
		}
		
	}
}
