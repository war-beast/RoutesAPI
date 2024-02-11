using BLL.Interfaces;
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
		services.AddTransient<ICachedDataService, CachedDataService>();

		#endregion

		#region Bussiness logic layer

		services.AddTransient<IDataService, ProviderOneSearchService>();
		services.AddTransient<IDataService, ProviderTwoSearchService>();
		services.AddTransient<IDataService, StoredDataService>();
		services.AddTransient<IDataProvidersFactory, DataProvidersFactory>();
		services.AddTransient<IStorageUpdateService, StorageUpdateService>();
		services.AddTransient<IFilterService, FilterService>();

		services.AddTransient<IAvailable, ProviderOneSearchService>();
		services.AddTransient<IAvailable, ProviderTwoSearchService>();

		services.AddTransient<IRoutesService, RoutesService>();
		services.AddTransient<ISearchService, SearchService>();

		#endregion

		#region Configuration

		services.Configure<ProviderOneConnection>(config.GetSection("RouteProvider:ProviderOne"));
		services.Configure<ProviderTwoConnection>(config.GetSection("RouteProvider:ProviderTwo"));

		#endregion
	}
}
