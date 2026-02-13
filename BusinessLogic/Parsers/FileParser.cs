using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace BusinessLogic.Parsers
{
	public class FileParser: IFileParser
	{
		public async Task<List<FileRowDto>> ParseCsvAsync(IFormFile file)
		{
			var result = new List<FileRowDto>();
			using var reader = new StreamReader(file.OpenReadStream());
			string line;
			int lineNumber = 0;
			while ((line = await reader.ReadLineAsync()) != null)
			{
				lineNumber++;
				if (lineNumber == 1)
				{
					continue;
				}
				if (string.IsNullOrWhiteSpace(line))
				{
					continue;
				}
				var parts = line.Split(';');
				if (parts.Length != 3)
				{
					throw new Exception($"Строка {lineNumber}: неверное количество колонок");
				}
				var row = new FileRowDto
				{
					Date = ParseCustomDate(parts[0]),
					ExecutionTime = double.Parse(parts[1]),
					Value = double.Parse(parts[2])
				};
				result.Add(row);
			}
			return result;
		}
		public DateTime ParseCustomDate(string dateString)
		{
			var parts = dateString.Split('T');
			var datePart = parts[0];
			var timePart = parts[1].Replace("-", ":");
			var normalizedDate = $"{datePart}T{timePart}";
			var date = DateTime.Parse(normalizedDate, CultureInfo.InvariantCulture);
			return DateTime.SpecifyKind(date, DateTimeKind.Utc);
		}
	}
}
