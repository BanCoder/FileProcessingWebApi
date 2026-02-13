using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
	public class ValueRepository: IValueRepository
	{
		private readonly ApplicationContext _context; 
		public ValueRepository(ApplicationContext context)
		{
			_context = context;
		}
		public async Task AddValueAsync(List<Value> values, CancellationToken cancellationToken)
		{
			foreach(var value in values)
			{
				value.CreatedAt = DateTime.UtcNow;
			}
			await _context.Values.AddRangeAsync(values, cancellationToken); 
			await _context.SaveChangesAsync(cancellationToken);
		}
		public async Task DeleteByFileNameAsync(string fileName, CancellationToken cancellationToken)
		{
			var values = await _context.Values.Where(v => v.FileName == fileName).ToListAsync(cancellationToken);
			_context.Values.RemoveRange(values);
			await _context.SaveChangesAsync(cancellationToken); 
		}
		public async Task<bool> ExistsByFileNameAsync(string fileName, CancellationToken cancellationToken)
		{
			return await _context.Values.AnyAsync(v => v.FileName == fileName); 
		}
		public async Task<List<Value>> GetLastTenValuesByFileNameAsync(string fileName, CancellationToken cancellationToken)
		{
			var lastValues = await _context.Values.Where(v => v.FileName == fileName).OrderByDescending(v => v.Date).Take(10).ToListAsync(cancellationToken); 
			return lastValues;
		}
		public async Task<List<Value>> GetByFileNameAsync(string fileName, CancellationToken cancellationToken)
		{
			return await _context.Values.Where(v => v.FileName == fileName).ToListAsync(cancellationToken); 
		}
	}
}
