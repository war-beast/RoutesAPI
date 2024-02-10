using BLL.Interfaces;
using BLL.Model;

namespace BLL.Services;

public class CacheSearchService : IDataConsumer
{
	private readonly ICacheDataService _cacheService;

	public CacheSearchService(ICacheDataService cacheService)
	{
		_cacheService = cacheService;
	}

	public Task<SearchResponse?> GetDataAsync(SearchRequest request, CancellationToken cancellationToken)
	{
		string key = ; //Сформировать ключ

		return _cacheService.ReadAsync(key, cancellationToken);
	}

	public Task<bool> IsAvailableAsync(CancellationToken cancellationToken) => Task.FromResult(true);
}
