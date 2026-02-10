using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class AppContext : DbContext
	{
		public AppContext(DbContextOptions<AppContext> options) : base(options) { }
		public DbSet<Value> Values { get; set; }
		public DbSet<Result> Results { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Value>(e =>
			{
				e.HasKey(v => v.Id);
				e.Property(v => v.FileName).IsRequired();
				e.Property(v => v.Date).IsRequired(); 
				e.Property(v => v.ExecutionTime).IsRequired();
				e.Property(v => v.IndicatorValue).IsRequired(); 
			});
			modelBuilder.Entity<Result>(e =>
			{
				e.HasKey(r => r.Id);
				e.Property(r => r.FileName).IsRequired();
				e.Property(r => r.StartDate).IsRequired();
				e.Property(r => r.DeltaSeconds).IsRequired(); 
				e.Property(r => r.AvgExecutionTime).IsRequired();
				e.Property(r => r.AvgValue).IsRequired();
				e.Property(r => r.MedianValue).IsRequired();
				e.Property(r => r.MaxValue).IsRequired();
				e.Property(r => r.MinValue).IsRequired();
			}); 
			base.OnModelCreating(modelBuilder);	 
		}
	}
}
