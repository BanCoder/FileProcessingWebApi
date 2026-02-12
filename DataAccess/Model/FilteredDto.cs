using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
	public class FilteredDto
	{
		public string? FileName { get; set; }
		public DateTime? StartDateFrom { get; set; }
		public DateTime? StartDateTo {  get; set; }
		public double? AvgValueFrom { get; set; }
		public double? AvgValueTo { get; set; }
		public double? AvgExecutionTimeFrom { get; set; }
		public double? AvgExecutionTimeTo { get; set; }
	}
}
