using BusinessLogic.Services.Interfaces;
using BusinessLogic.Validation;
using DataAccess.Model;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Services
{
	public class ValidatorService: IValidatorService
	{
		private readonly FileValidator _fileValidator;
		private readonly FileRowValidator _rowValidator;
		public ValidatorService(FileValidator fileValidator, FileRowValidator rowValidator)
		{
			_fileValidator = fileValidator;
			_rowValidator = rowValidator;
		}
		public async Task ValidateFileAsync(IFormFile file)
		{
			var fileValidation = await _fileValidator.ValidateAsync(file);
			if (!fileValidation.IsValid)
			{
				throw new ValidationException(fileValidation.Errors.ToString());
			}
		}
		public async Task ValidateRowsAsync(List<FileRowDto> rows)
		{
			if (rows.Count < 1 || rows.Count > 10000)
			{
				throw new ValidationException($"Количество строк файла: {rows.Count}. Допустимй диапозон (1-10000)");
			}
			var errors = new List<string>();
			for (int i = 0; i < rows.Count; i++)
			{
				var rowValidation = await _rowValidator.ValidateAsync(rows[i]);
				if (!rowValidation.IsValid)
				{
					var rowErrors = rowValidation.Errors.Select(e => $"Строка {i + 2}: {e.ErrorMessage}");
					errors.AddRange(rowErrors);
				}
			}
			if (errors.Any())
			{
				throw new ValidationException(string.Join("; ", errors));
			}
		}
	}
}
