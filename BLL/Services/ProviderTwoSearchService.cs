using BLL.Interfaces;
using BLL.Model;
using DAL.Interfaces;
using DAL.Model;

namespace BLL.Services;

public class ProviderTwoSearchService : IDataConsumer
{
	private readonly IProviderTwoService _providerService;

	public ProviderTwoSearchService(IProviderTwoService providerService)
    {
		_providerService = providerService;
	}

    public async Task<SearchResponse?> GetDataAsync(SearchRequest request, CancellationToken cancellationToken)
	{
		ProviderTwoSearchRequest providerSearchRequest = ; //Надо смаппить из request

		var requestResult = await _providerService.GetRoutesAsync(providerSearchRequest, cancellationToken);
		SearchResponse? result = ; //Надо смаппить из requestResult.Routes[]

		return result;
	}

	public Task<bool> IsAvailableAsync(CancellationToken cancellationToken) => _providerService.IsAvailableAsync(cancellationToken);
}
