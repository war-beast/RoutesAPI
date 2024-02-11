using BLL.Interfaces;
using BLL.Model;
using DAL.Interfaces;

namespace BLL.Services;

public class SearchService : ISearchService
{
	private readonly IDataProvidersFactory _providersFactory;
	private readonly IStorageUpdateService _storageUpdateService;

	public SearchService(IDataProvidersFactory providersFactory, 
		IStorageUpdateService storageUpdateService)
	{
		_providersFactory = providersFactory;
		_storageUpdateService = storageUpdateService;
	}

	public Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken)
	{
		var providers = _providersFactory.GetDataServices(request.Filters?.OnlyCached ?? false);


	}
}