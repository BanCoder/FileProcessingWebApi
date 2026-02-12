using DataAccess.Model;
using FluentValidation;

namespace BusinessLogic.Validation
{
	public class FileRowValidator: AbstractValidator<FileRowDto>
	{
		public FileRowValidator()
		{
			RuleFor(x => x.Date).NotEmpty().LessThanOrEqualTo(DateTime.UtcNow).GreaterThanOrEqualTo(new DateTime(2000, 1, 1));
			RuleFor(x => x.ExecutionTime).GreaterThanOrEqualTo(0); 
			RuleFor(x => x.Value).GreaterThanOrEqualTo(0);
		}
	}
}
