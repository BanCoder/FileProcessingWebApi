namespace DataAccess.Model
{
	public class Value
	{
		public Guid Id { get; set; }
		public string FileName { get; set; }
		public DateTime Date { get; set; }
		public double ExecutionTime { get; set; }
		public double IndicatorValue { get; set; }
		public DateTime CreatedAt { get; set; } 
	}
}
