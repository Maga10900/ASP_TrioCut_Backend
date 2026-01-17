using Microsoft.Extensions.DependencyInjection;
namespace TriVibe.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddMediatR(services => services.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
		return services;
	}
}
