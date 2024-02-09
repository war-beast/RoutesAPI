using DAL.Model;

namespace DAL.Interfaces;

public interface IProviderOneService : IProviderAvailable
{
	Task<ProviderOneSearchResponse> GetRoutes(ProviderOneSearchRequest request);
}
