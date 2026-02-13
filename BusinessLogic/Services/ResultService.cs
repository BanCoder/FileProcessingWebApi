using BusinessLogic.Services.Interfaces;
using DataAccess.Model;
using DataAccess.Repository;

namespace BusinessLogic.Services
{
	public class ResultService: IResultService
	{
		private readonly IResultRepository _resultRepository; 
		public ResultService(IResultRepository resultRepository)
		{
			_resultRepository = resultRepository;
		}
		public async Task<List<Result>> GetFiltredFilesAsync(FilteredDto filter)
		{
			return await _resultRepository.GetFiltredAsync(filter.FileName, filter.StartDateFrom, filter.StartDateTo, filter.AvgValueFrom, filter.AvgValueTo, filter.AvgExecutionTimeFrom, filter.AvgExecutionTimeTo);
		}
	}
}
