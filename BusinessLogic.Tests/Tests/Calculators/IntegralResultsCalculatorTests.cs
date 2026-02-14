using BusinessLogic.Calculation;
using DataAccess.Model;
using Xunit;

namespace BusinessLogic.Tests.Calculators
{
	public class IntegralResultsCalculatorTests
	{
		private readonly IntegralResultsCalculator _calculator; 
		public IntegralResultsCalculatorTests()
		{
			_calculator = new IntegralResultsCalculator();
		}
		[Fact]
		public void CalculateMedianValue_WithOddCount_ReturnsMiddleValue()
		{
			// Arrange
			var values = new List<double> { 1, 2, 3, 4, 5 }; 
			// Act
			var result = _calculator.CalculateMedianValue(values);
			// Assert
			Assert.Equal(3,result);
		}
		[Fact]
		public void CalculateMedianValue_WithEvenCount_ReturnsAverageOfTwoMiddle()
		{
			// Arrange
			var values = new List<double> { 1, 2, 3, 4 };
			// Act
			var result = _calculator.CalculateMedianValue(values);
			// Assert
			Assert.Equal(2.5, result);
		}
		[Fact]
		public void CalculateDeltaSeconds_ReturnsCorrectDifference()
		{
			// Arrange
			var values = new List<Value>
			{
				new Value { Date = new DateTime(2024, 1, 1, 10, 0, 0) },
				new Value { Date = new DateTime(2024, 1, 1, 10, 5, 0) },
				new Value { Date = new DateTime(2024, 1, 1, 10, 2, 0) }
			};
			// Act
			var results = _calculator.CalculateDeltaSeconds(values);
			// Assert
			Assert.Equal(300, results); 
		}
		[Fact]
		public void CalculateAvgValue_ReturnsCorrectAverage()
		{
			// Arrange
			var values = new List<Value>
			{
				new Value { IndicatorValue = 10 },
				new Value { IndicatorValue = 20 },
				new Value { IndicatorValue = 30 }
			};
			// Act
			var results = _calculator.CalculateAvgValue(values);
			// Assert
			Assert.Equal(20, results);
		}
	}
}
