using BLL.Interfaces;
using BLL.Model;
using DAL.Interfaces;
using DAL.Model;

namespace BLL.Services;

public class ProviderOneSearchService : IDataConsumer
{
	private readonly IProviderOneService _providerService;

	public ProviderOneSearchService(IProviderOneService providerService)
	{
		_providerService = providerService;
	}

	public async Task<SearchResponse> GetDataAsync(SearchRequest request, CancellationToken cancellationToken)
	{
		ProviderOneSearchRequest providerSearchRequest = ; //Надо смаппить из request

		var requestResult = await _providerService.GetRoutesAsync(providerSearchRequest, cancellationToken);
		SearchResponse result = ; //Надо смаппить из requestResult.Routes[]

		return result;
	}

	public Task<bool> IsAvailableAsync(CancellationToken cancellationToken) => _providerService.IsAvailableAsync(cancellationToken);
}
