using DAL.Interfaces;
using DAL.Model;

namespace DAL.Services;

public class ProviderTwoService : IProviderTwoService
{
	public Task<ProviderTwoSearchResponse> GetRoutes(ProviderTwoSearchRequest request)
	{
		throw new NotImplementedException();
	}

	public Task<bool> IsAvailable()
	{
		throw new NotImplementedException();
	}
}
