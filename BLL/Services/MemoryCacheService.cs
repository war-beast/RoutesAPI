using BLL.Interfaces;
using BLL.Model;
using Microsoft.Extensions.Caching.Memory;

namespace BLL.Services;

public class MemoryCacheService : ICacheDataService<MemoryCacheKey>
{
	private readonly IMemoryCache _cache;

	private const int ExpirationHoursOffset = 12;

	public MemoryCacheService(IMemoryCache cache)
	{
		_cache = cache;
	}

	public Task<SearchResponse> ReadAsync(MemoryCacheKey key, CancellationToken cancellationToken)
	{
		var readSuccess = _cache.TryGetValue(key, out SearchResponse? item);

		return readSuccess && item != null 
			? Task.FromResult(item) 
			: Task.FromResult(new SearchResponse{ Routes = [] });
	}

	public Task WriteAsync(MemoryCacheKey key, SearchResponse item, CancellationToken cancellationToken)
	{
		_cache.Set(key, item, DateTimeOffset.Now.AddHours(ExpirationHoursOffset));

		return Task.CompletedTask;
	}
}