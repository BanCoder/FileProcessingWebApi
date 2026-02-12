using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
namespace TestTaskWeb.Controllers
{
	[ApiController]
	[Route("api/files")]
	public class FileController : ControllerBase
	{
		private readonly IFileProcessingService _fileservice;
		private readonly IValueService _valueService;
		public FileController(IFileProcessingService fileservice, IValueService valueService)
		{
			_fileservice = fileservice;
			_valueService = valueService;
		}
		[HttpPost("upload")]
		public async Task<IActionResult> UploadFile(IFormFile file)
		{
			await _fileservice.ProcessFileAsync(file);
			return Ok("Файл успешно обработан");
		}
		[HttpGet("{fileName}/last-values")]
		public async Task<IActionResult> GetLastValues(string fileName)
		{
			var values = await _valueService.GetLastTenValuesAsync(fileName);
			return Ok(values);
		}
	}
}
