using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public interface IValueRepository
	{
		Task AddRangeAsync(List<Value> values, CancellationToken cancellationToken = default);
		Task DeleteByFileNameAsync(string fileName, CancellationToken cancellationToken = default); 
		Task<bool> ExistsByFileNameAsync(string fileName, CancellationToken cancellationToken = default);
		Task<List<Value>> GetLastTenValuesByFileNameAsync(string fileName, CancellationToken cancellationToken = default);
		Task<List<Value>> GetByFileNameAsync(string fileName, CancellationToken cancellationToken = default);
	}
}
