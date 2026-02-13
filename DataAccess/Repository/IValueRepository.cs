using DataAccess.Model;

namespace DataAccess.Repository
{
	public interface IValueRepository
	{
		Task AddValueAsync(List<Value> values, CancellationToken cancellationToken = default);
		Task DeleteByFileNameAsync(string fileName, CancellationToken cancellationToken = default); 
		Task<bool> ExistsByFileNameAsync(string fileName, CancellationToken cancellationToken = default);
		Task<List<Value>> GetLastTenValuesByFileNameAsync(string fileName, CancellationToken cancellationToken = default);
		Task<List<Value>> GetByFileNameAsync(string fileName, CancellationToken cancellationToken = default);
	}
}
