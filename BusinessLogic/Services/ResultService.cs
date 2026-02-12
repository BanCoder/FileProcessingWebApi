using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
