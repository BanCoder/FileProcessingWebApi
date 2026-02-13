using DataAccess.Model;

namespace BusinessLogic.Calculation
{
	public class IntegralResultsCalculator: IIntegralResultsCalculator
	{
		public DateTime CalculateStartDate(List<Value> values)
		{
			return values.Min(v => v.Date);
		}
		public double CalculateDeltaSeconds(List<Value> values)
		{
			return (values.Max(v => v.Date) - values.Min(v => v.Date)).TotalSeconds; 
		}
		public double CalculateAvgExecutionTime(List<Value> values)
		{
			return values.Average(v => v.ExecutionTime); 
		}
		public double CalculateAvgValue(List<Value> values)
		{
			return values.Average(v => v.IndicatorValue); 
		}
		
		public double CalculateMaxValue(List<Value> values)
		{
			return values.Max(v => v.IndicatorValue); 
		}
		public double CalculateMinValue(List<Value> values)
		{
			return values.Min(v => v.IndicatorValue); 
		}
		public double CalculateMedianValue(List<double> values)
		{
			var sorted = values.OrderBy(v => v).ToList();
			int count = sorted.Count;
			if (count % 2 == 0)
			{
				return (sorted[count / 2 - 1] + sorted[count / 2]) / 2;
			}
			else
			{
				return sorted[count / 2];
			}
		}
	}
}
