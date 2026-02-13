using DataAccess.Model;

namespace BusinessLogic.Factories
{
	public interface IEntityFactory
	{
		List<Value> CreateValueEntities(string fileName, List<FileRowDto> rows);
		Result CreateResultEntity(string fileName, List<Value> values); 
	}
}
