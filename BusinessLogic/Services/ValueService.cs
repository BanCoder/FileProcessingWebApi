using BusinessLogic.Services.Interfaces;
using DataAccess.Model;
using DataAccess.Repository;

namespace BusinessLogic.Services
{
	public class ValueService: IValueService
	{
		private readonly IValueRepository _valueRepository; 
		public ValueService(IValueRepository valueRepository)
		{
			_valueRepository = valueRepository;
		}
		public async Task<List<Value>> GetLastTenValuesAsync(string fileName)
		{
			bool isFileExist = await _valueRepository.ExistsByFileNameAsync(fileName);
			if (!isFileExist)
			{
				throw new Exception($"Файл с именем {fileName} не найден");
			}
			return await _valueRepository.GetLastTenValuesByFileNameAsync(fileName);
		}
	}
}
