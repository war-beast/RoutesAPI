using DAL.Model;

namespace DAL.Interfaces;

public interface IProviderTwoService : IProviderAvailable
{
	Task<ProviderTwoSearchResponse> GetRoutes(ProviderTwoSearchRequest request);
}
