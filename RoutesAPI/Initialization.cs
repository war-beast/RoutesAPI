using DAL.Interfaces;
using DAL.Services;

namespace RoutesAPI;

public static class Initialization
{
	public static void InitCustomServices(this IServiceCollection services)
	{
		#region Data layer

		services.AddTransient<IProviderOneService, ProviderOneService>();
		services.AddTransient<IProviderTwoService, ProviderTwoService>();

		#endregion

		#region Bussiness logic layer



		#endregion
	}
}
