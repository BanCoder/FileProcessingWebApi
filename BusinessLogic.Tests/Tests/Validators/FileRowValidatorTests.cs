using BusinessLogic.Validation;
using DataAccess.Model; 
using Xunit;

namespace BusinessLogic.Tests.Validators
{
	public class FileRowValidatorTests
	{
		private readonly FileRowValidator _validator; 
		public FileRowValidatorTests()
		{
			_validator = new FileRowValidator(); 
		}
		[Fact] 
		public void Validate_ValidRow_ReturnsSuccess()
		{
			// Arrange
			var row = new FileRowDto
			{
				Date = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc),
				ExecutionTime = 5.5,
				Value = 10
			}; 
			// Act
			var result = _validator.Validate(row);
			//Assert
			Assert.True(result.IsValid); 
		}
		[Fact]
		public void Validate_DateInFuture_ReturnsError()
		{
			// Arrange
			var row = new FileRowDto
			{
				Date = DateTime.UtcNow.AddDays(1),
				ExecutionTime = 5.5,
				Value = 10.0
			};
			// Act
			var result = _validator.Validate(row);
			// Assert
			Assert.False(result.IsValid);
			Assert.Contains(result.Errors, e => e.PropertyName == "Date");
		}
		[Fact]
		public void Validate_NegativeExecutionTime_ReturnsError()
		{
			// Arrange
			var row = new FileRowDto
			{
				Date = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc),
				ExecutionTime = -1,
				Value = 10.0
			};
			// Act
			var result = _validator.Validate(row);
			// Assert
			Assert.False(result.IsValid);
			Assert.Contains(result.Errors, e => e.PropertyName == "ExecutionTime");
		}
	}
}
