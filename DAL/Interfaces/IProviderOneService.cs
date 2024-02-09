using DAL.Model;

namespace DAL.Interfaces;

public interface IProviderOneService : IProviderAvailable
{
	Task<ProviderOneSearchResponse> GetRoutesAsync(ProviderOneSearchRequest request, CancellationToken cancellationToken);
}
