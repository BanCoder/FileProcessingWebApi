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
			foreach (var row in rows)
			{
				var rowValidation = await _rowValidator.ValidateAsync(row);
				if (!rowValidation.IsValid)
				{
					throw new ValidationException(rowValidation.Errors.ToString());
				}
			}
		}
	}
}
