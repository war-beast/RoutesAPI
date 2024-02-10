using AutoMapper;
using BLL.Interfaces;
using BLL.Model;

namespace BLL.Services;

public class CacheSearchService : IDataConsumer
{
	private readonly ICacheDataService<MemoryCacheKey> _cacheService;
	private readonly IMapper _mapper;

	public CacheSearchService(ICacheDataService<MemoryCacheKey> cacheService, 
		IMapper mapper)
	{
		_cacheService = cacheService;
		_mapper = mapper;
	}

	public Task<SearchResponse> GetDataAsync(SearchRequest request, CancellationToken cancellationToken)
	{
		var key = _mapper.Map<MemoryCacheKey>(request); //Сформировать ключ

		return _cacheService.ReadAsync(key, cancellationToken);
	}

	public Task<bool> IsAvailableAsync(CancellationToken cancellationToken) => Task.FromResult(true);
}
