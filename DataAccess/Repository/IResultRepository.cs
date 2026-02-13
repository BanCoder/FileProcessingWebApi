using DataAccess.Model;

namespace DataAccess.Repository
{
	public interface IResultRepository
	{
		Task AddAsync(Result result, CancellationToken cancellationToken = default); 
		Task UpdateAsync(Result result, CancellationToken cancellationToken = default);
		Task DeleteAsync(Result result, CancellationToken cancellationToken = default);
		Task<Result?> GetByFileNameAsync(string fileName, CancellationToken cancellationToken = default);
		Task<List<Result>> GetFiltredAsync(string? fileName, DateTime? startDateFrom, DateTime? startDateTo, double? avgValueFrom, double? avgValueTo, double? avgExecutionTimeFrom, double? avgExecutionTimeTo, CancellationToken cancellationToken = default);
		Task<List<Result>> GetAllAsync(CancellationToken cancellationToken = default); 
	}
}
