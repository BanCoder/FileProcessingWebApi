using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Validation
{
	public class FileValidator: AbstractValidator<IFormFile>
	{
		public FileValidator()
		{
			RuleFor(x => x.Length).GreaterThan(0).WithMessage("Файл пуст"); 
		}
	}
}
