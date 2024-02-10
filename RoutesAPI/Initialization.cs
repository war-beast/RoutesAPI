using BLL.Interfaces;
using BLL.Model;
using BLL.Services;
using DAL.Interfaces;
using DAL.Model.Options;
using DAL.Services;

namespace RoutesAPI;

public static class Initialization
{
	public static void InitCustomServices(this IServiceCollection services, ConfigurationManager config)
	{
		#region Data layer

		services.AddTransient<IProviderOneService, ProviderOneService>();
		services.AddTransient<IProviderTwoService, ProviderTwoService>();

		#endregion

		#region Bussiness logic layer

		services.AddTransient<ICacheDataService<MemoryCacheKey>, MemoryCacheService>();

		#endregion

		#region Configuration

		services.Configure<ProviderOneConnection>(config.GetSection("RouteProvider:ProviderOne"));
		services.Configure<ProviderTwoConnection>(config.GetSection("RouteProvider:ProviderTwo"));

		#endregion
	}
}
