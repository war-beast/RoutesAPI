using DAL.Model;

namespace DAL.Interfaces;

public interface IProviderTwoService : IProviderAvailable
{
	Task<ProviderTwoSearchResponse> GetRoutesAsync(ProviderTwoSearchRequest request);
}
