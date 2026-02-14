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
			string? line;
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
					ExecutionTime = double.Parse(parts[1], CultureInfo.InvariantCulture),
					Value = double.Parse(parts[2])
				};
				result.Add(row);
			}
			return result;
		}
		public DateTime ParseCustomDate(string dateString)
		{
			var datePart = dateString.Substring(0, 10);
			var timePart = dateString.Substring(11);
			var timeParts = timePart.Split('-');
			if (timeParts.Length == 3)
			{
				var milliseconds = timeParts[2];
				var formattedTime = $"{timeParts[0]}:{timeParts[1]}:{milliseconds}";
				var fullDateString = $"{datePart}T{formattedTime}";
				return DateTime.Parse(fullDateString, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
			}
			throw new FormatException($"Неверный формат даты: {dateString}");
		}
	}
}
