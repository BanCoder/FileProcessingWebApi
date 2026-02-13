using BusinessLogic.Calculation;
using BusinessLogic.Factories;
using BusinessLogic.Parsers;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using BusinessLogic.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
	public static class Extensions
	{
		public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<IFileProcessingService, FileProcessingService>(); 
			serviceCollection.AddScoped<IValueService, ValueService>();
			serviceCollection.AddScoped<IResultService, ResultService>();
			serviceCollection.AddScoped<IValidatorService, ValidatorService>();
			serviceCollection.AddScoped<IIntegralResultsCalculator, IntegralResultsCalculator>(); 
			serviceCollection.AddScoped<IEntityFactory, EntityFactory>();
			serviceCollection.AddScoped<IFileParser, FileParser>();
			serviceCollection.AddScoped<FileValidator>();
			serviceCollection.AddScoped<FileRowValidator>(); 
			return serviceCollection;
		}
	}
}
