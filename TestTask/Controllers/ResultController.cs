using BusinessLogic.Services.Interfaces;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
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
