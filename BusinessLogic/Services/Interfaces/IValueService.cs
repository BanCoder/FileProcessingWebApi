using DataAccess.Model;

namespace BusinessLogic.Services.Interfaces
{
	public interface IValueService
	{
		Task<List<Value>> GetLastTenValuesAsync(string fileName);
	}
}
