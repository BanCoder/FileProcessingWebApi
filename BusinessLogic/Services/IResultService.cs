using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
	public interface IResultService
	{
		Task<List<Result>> GetFiltredFilesAsync(FilteredDto filter);
	}
}
