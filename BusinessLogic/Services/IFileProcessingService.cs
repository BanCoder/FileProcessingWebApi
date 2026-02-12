using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services
{
	public interface IFileProcessingService
	{
		Task ProcessFileAsync(IFormFile file);
	}
}
