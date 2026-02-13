using DataAccess.Model;

namespace BusinessLogic.Calculation
{
	public interface IIntegralResultsCalculator
	{
		DateTime CalculateStartDate(List<Value> values);
		double CalculateDeltaSeconds(List<Value> values);
		double CalculateAvgExecutionTime(List<Value> values);
		double CalculateAvgValue(List<Value> values);
		double CalculateMaxValue(List<Value> values);
		double CalculateMinValue(List<Value> values);
		double CalculateMedianValue(List<double> values); 
	}
}
