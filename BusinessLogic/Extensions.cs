using BusinessLogic.Services;
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
			return serviceCollection;
		}
	}
}
