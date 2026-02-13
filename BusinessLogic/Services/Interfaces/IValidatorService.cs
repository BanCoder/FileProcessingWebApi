using DataAccess.Model;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services.Interfaces
{
	public interface IValidatorService
	{
		Task ValidateFileAsync(IFormFile file);
		Task ValidateRowsAsync(List<FileRowDto> rows); 
	}
}
