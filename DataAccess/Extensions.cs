using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
	public static class Extensions
	{
		public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			serviceCollection.AddDbContext<AppContext>(x =>
			{
				x.UseNpgsql(connectionString);
			});
			return serviceCollection; 
		}
	}
}
