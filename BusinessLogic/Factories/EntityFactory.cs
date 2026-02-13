using BusinessLogic.Calculation;
using DataAccess.Model;

namespace BusinessLogic.Factories
{
	public class EntityFactory: IEntityFactory
	{
		private readonly IIntegralResultsCalculator _calculator;
		public EntityFactory(IIntegralResultsCalculator calculator)
		{
			_calculator = calculator;
		}
		public List<Value> CreateValueEntities(string fileName, List<FileRowDto> rows)
		{
			var values = rows.Select(r => new Value
			{
				FileName = fileName,
				Date = r.Date,
				ExecutionTime = r.ExecutionTime,
				IndicatorValue = r.Value,
				CreatedAt = DateTime.UtcNow
			}).ToList();
			return values;
		}
		public Result CreateResultEntity(string fileName, List<Value> values)
		{
			var indicatorValues = values.Select(v => v.IndicatorValue).ToList();
			var result = new Result
			{
				FileName = fileName,
				StartDate = _calculator.CalculateStartDate(values),
				DeltaSeconds = _calculator.CalculateDeltaSeconds(values),
				AvgExecutionTime = _calculator.CalculateAvgExecutionTime(values),
				AvgValue = _calculator.CalculateAvgValue(values),
				MedianValue = _calculator.CalculateMedianValue(indicatorValues),
				MaxValue = _calculator.CalculateMaxValue(values),
				MinValue = _calculator.CalculateMinValue(values),
				CreatedAt = DateTime.UtcNow
			};
			return result;
		}
	}
}
