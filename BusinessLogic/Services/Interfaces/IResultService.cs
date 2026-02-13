using DataAccess.Model;

namespace BusinessLogic.Services.Interfaces
{
	public interface IResultService
	{
		Task<List<Result>> GetFiltredFilesAsync(FilteredDto filter);
	}
}
