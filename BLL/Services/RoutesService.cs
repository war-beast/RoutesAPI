using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DAL.Interfaces;

namespace BLL.Services;

public class RoutesService : IRoutesService
{
	private readonly ICachedDataService _cachedDataService;
	private readonly IMapper _mapper;

	public RoutesService(ICachedDataService cachedDataService, 
		IMapper mapper)
	{
		_cachedDataService = cachedDataService;
		_mapper = mapper;
	}

	public async Task<Route> GetRouteAsync(Guid id, CancellationToken cancellationToken)
	{
		var route = await _cachedDataService.GetById(id, cancellationToken);
		return _mapper.Map<Route>(route);
	}
}