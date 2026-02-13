using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
	public class ResultRepository: IResultRepository
	{
		private readonly ApplicationContext _context; 
		public ResultRepository(ApplicationContext context)
		{
			_context = context;
		}
		public async Task AddAsync(Result result, CancellationToken cancellationToken)
		{
			result.CreatedAt = DateTime.UtcNow; 
			await _context.Results.AddAsync(result, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
		}
		public async Task UpdateAsync(Result result, CancellationToken cancellationToken)
		{
			_context.Results.Update(result); 
			await _context.SaveChangesAsync(cancellationToken);
		}
		public async Task DeleteAsync(Result result, CancellationToken cancellationToken)
		{
			_context.Results.RemoveRange(result);
			await _context.SaveChangesAsync(cancellationToken); 
		}
		public async Task<Result?> GetByFileNameAsync(string fileName, CancellationToken cancellationToken)
		{
			var results = await _context.Results.Where(r => r.FileName == fileName).FirstOrDefaultAsync(cancellationToken);
			return results; 
		}
		public async Task<List<Result>> GetFiltredAsync(string? fileName, DateTime? startDateFrom, DateTime? startDateTo, double? avgValueFrom, double? avgValueTo, double? avgExecutionTimeFrom, double? avgExecutionTimeTo, CancellationToken cancellationToken)
		{
			var query = _context.Results.AsQueryable();
			if (!string.IsNullOrEmpty(fileName))
			{
				query = query.Where(r => r.FileName == fileName); 
			}
			if (startDateFrom.HasValue)
			{
				query = query.Where(r => r.StartDate >=  startDateFrom.Value);
			}
			if (startDateTo.HasValue)
			{
				query = query.Where(r => r.StartDate <= startDateTo.Value);
			}
			if (avgValueFrom.HasValue)
			{
				query = query.Where(r => r.AvgValue >= avgValueFrom.Value);
			}
			if (avgValueTo.HasValue)
			{
				query = query.Where(r => r.AvgValue <= avgValueTo.Value);
			}
			if (avgExecutionTimeFrom.HasValue)
			{
				query = query.Where(r => r.AvgExecutionTime >= avgExecutionTimeFrom.Value);
			}
			if (avgExecutionTimeTo.HasValue)
			{
				query = query.Where(r => r.AvgExecutionTime <= avgExecutionTimeTo.Value);
			}
			return await query.ToListAsync(cancellationToken); 
		}
		public async Task<List<Result>> GetAllAsync(CancellationToken cancellationToken)
		{
			return await _context.Results.ToListAsync(cancellationToken); 
		}
	}
}
