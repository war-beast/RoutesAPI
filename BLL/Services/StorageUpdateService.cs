using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class StorageUpdateService : IStorageUpdateService
{
	private readonly ICachedDataService _cachedDataService;
	private readonly IMapper _mapper;

	public StorageUpdateService(ICachedDataService cachedDataService, IMapper mapper)
	{
		_cachedDataService = cachedDataService;
		_mapper = mapper;
	}

	public Task SaveNewRoutes(IReadOnlyCollection<Route> routes, CancellationToken cancellationToken) => _cachedDataService.AddRoutes(_mapper.Map<IReadOnlyCollection<RouteInfo>>(routes), cancellationToken);
}