using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
			try
			{
				await _fileservice.ProcessFileAsync(file);
				return Ok("Файл успешно обработан");
			}
			catch(ValidationException ex)
			{
				return BadRequest(new
				{
					error = "Файл не прошел валидацию", 
					details = ex.Message
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { error = $"Внутренняя ошибка сервера: {ex.Message}" });
			}
		}
		[HttpGet("{fileName}/last-values")]
		public async Task<IActionResult> GetLastValues(string fileName)
		{
			try
			{
				var values = await _valueService.GetLastTenValuesAsync(fileName);
				return Ok(values);
			}
			catch(Exception ex)
			{
				return StatusCode(500, new { error = ex.Message }); 
			}
		}
	}
}
