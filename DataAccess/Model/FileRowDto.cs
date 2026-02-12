using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
	public class FileRowDto
	{
		public DateTime Date {  get; set; }
		public double ExecutionTime { get; set; }
		public double Value { get; set; }
	}
}
