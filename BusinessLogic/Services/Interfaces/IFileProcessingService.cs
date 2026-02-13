using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services.Interfaces
{
	public interface IFileProcessingService
	{
		Task ProcessFileAsync(IFormFile file);
	}
}
