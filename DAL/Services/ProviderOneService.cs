using DAL.Interfaces;
using DAL.Model;

namespace DAL.Services;

public class ProviderOneService : IProviderOneService
{
	public Task<ProviderOneSearchResponse> GetRoutes(ProviderOneSearchRequest request)
	{
		throw new NotImplementedException();
	}

	public Task<bool> IsAvailable()
	{
		throw new NotImplementedException();
	}
}
