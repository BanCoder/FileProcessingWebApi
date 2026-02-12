using BusinessLogic.Validation;
using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Services
{
	public class FileProcessingService: IFileProcessingService
	{
		private readonly IValueRepository _valueRepository;
		private readonly IResultRepository _resultRepository;
		private readonly FileValidator _fileValidator;
		private readonly FileRowValidator _rowValidator; 
		public FileProcessingService(FileValidator fileValidator, FileRowValidator rowValidator, IValueRepository valueRepository, IResultRepository resultRepository)
		{
			_fileValidator = fileValidator;
			_rowValidator = rowValidator;
			_valueRepository = valueRepository;
			_resultRepository = resultRepository;
		}
		public async Task ProcessFileAsync(IFormFile file)
		{
			var fileValidation = await _fileValidator.ValidateAsync(file);
			if (!fileValidation.IsValid)
			{
				throw new ValidationException(fileValidation.Errors.ToString()); 
			}
			List<FileRowDto> rows = await ParseCsvAsync(file); 
			if(rows.Count < 1 || rows.Count > 10000)
			{
				throw new ValidationException($"Количество строк файла: {rows.Count}. Допустимй диапозон (1-10000)");
			}
			foreach(var row in rows)
			{
				var rowValidation = await _rowValidator.ValidateAsync(row);
				if (!rowValidation.IsValid)
				{
					throw new ValidationException(rowValidation.Errors.ToString()); 
				}
			}
		}
		public async Task<List<FileRowDto>> ParseCsvAsync(IFormFile file)
		{
			var result = new List<FileRowDto>();
			using var reader = new StreamReader(file.OpenReadStream());
			string line;
			int lineNumber = 0; 
			while((line = await reader.ReadLineAsync()) != null)
			{
				lineNumber++; 
				if(lineNumber == 1)
				{
					continue;
				}
				var parts = line.Split(';');
				if(parts.Length != 3)
				{
					throw new Exception($"Строка {lineNumber}: неверное количество колонок"); 
				}
				var row = new FileRowDto
				{
					Date = DateTime.Parse(parts[0]), 
					ExecutionTime = double.Parse(parts[1]),
					Value = double.Parse(parts[2])
				}; 
				result.Add(row);
			}
			return result; 
		}
	}
}
