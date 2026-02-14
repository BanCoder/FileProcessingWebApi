using DataAccess.Model;
using FluentValidation;

namespace BusinessLogic.Validation
{
	public class FileRowValidator: AbstractValidator<FileRowDto>
	{
		public FileRowValidator()
		{
			RuleFor(x => x.Date).NotEmpty().WithMessage("Дата не может быть пустой").LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Дата не может быть позже текущей").GreaterThanOrEqualTo(new DateTime(2000, 1, 1)).WithMessage("Дата не может быть раньше 01.01.2000");
			RuleFor(x => x.ExecutionTime).GreaterThanOrEqualTo(0).WithMessage("Время выполнения не может быть отрицательным"); 
			RuleFor(x => x.Value).GreaterThanOrEqualTo(0).WithMessage("Значение показателя не может быть отрицательным");
		}
	}
}
