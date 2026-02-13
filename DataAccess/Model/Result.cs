namespace DataAccess.Model
{
	public class Result
	{
		public Guid Id { get; set; }
		public string FileName { get; set; }
		public DateTime StartDate { get; set; }
		public double DeltaSeconds { get; set; }
		public double AvgExecutionTime { get; set; }
		public double AvgValue { get; set; }
		public double MedianValue { get; set; }
		public double MaxValue { get; set; }
		public double MinValue { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
