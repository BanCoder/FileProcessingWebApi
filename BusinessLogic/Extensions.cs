using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
	public static class Extensions
	{
		public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
		{
			return serviceCollection;
		}
	}
}
