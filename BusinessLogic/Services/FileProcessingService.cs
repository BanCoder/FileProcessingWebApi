using BusinessLogic.Factories;
using BusinessLogic.Parsers;
using BusinessLogic.Services.Interfaces;
using DataAccess;
using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services
{
	public class FileProcessingService: IFileProcessingService
	{
		private readonly IValueRepository _valueRepository;
		private readonly IResultRepository _resultRepository;
		private readonly IValidatorService _validator;
		private readonly ApplicationContext _context;
		private readonly IEntityFactory _factory; 
		private readonly IFileParser _parser; 
		public FileProcessingService(IValidatorService validator,IValueRepository valueRepository, IResultRepository resultRepository, ApplicationContext context, IEntityFactory factory, IFileParser parser)
		{
			_valueRepository = valueRepository;
			_resultRepository = resultRepository;
			_context = context;
			_factory = factory;
			_parser = parser;
			_validator = validator;
		}
		public async Task ProcessFileAsync(IFormFile file)
		{
			await _validator.ValidateFileAsync(file);
			List<FileRowDto> rows = await _parser.ParseCsvAsync(file); 
			await _validator.ValidateRowsAsync(rows);
			await ProcessFileDataAsync(file.FileName, rows);
		}
		private async Task ProcessFileDataAsync(string fileName, List<FileRowDto> rows)
		{
			await using var transaction = await _context.Database.BeginTransactionAsync();
			try
			{
				await DeleteExistingDataAsync(fileName);
				var values = _factory.CreateValueEntities(fileName, rows);
				await _valueRepository.AddValueAsync(values);

				var result = _factory.CreateResultEntity(fileName, values);
				await _resultRepository.AddAsync(result); 

				await transaction.CommitAsync();
			}
			catch
			{
				await transaction.RollbackAsync();
				throw; 
			}
		}
		private async Task DeleteExistingDataAsync(string fileName)
		{
			if(await _valueRepository.ExistsByFileNameAsync(fileName))
			{
				await _valueRepository.DeleteByFileNameAsync(fileName);
				var existingResult = await _resultRepository.GetByFileNameAsync(fileName);
				if(existingResult != null)
				{
					await _resultRepository.DeleteAsync(existingResult);
				}
			}
		}
	}
}
