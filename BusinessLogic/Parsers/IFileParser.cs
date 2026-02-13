using DataAccess.Model;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Parsers
{
	public interface IFileParser
	{
		Task<List<FileRowDto>> ParseCsvAsync(IFormFile file);
		DateTime ParseCustomDate(string dateString); 
	}
}
