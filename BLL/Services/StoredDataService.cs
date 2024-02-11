using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public class StoredDataService : IDataService
{
	private readonly ICachedDataService _cachedDataService;
	private readonly IMapper _mapper;

	public StoredDataService(ICachedDataService cachedDataService, IMapper mapper)
	{
		_cachedDataService = cachedDataService;
		_mapper = mapper;
	}

	public async Task<Route[]> GetDataAsync(SearchRequest request, CancellationToken cancellationToken)
	{
		var query = _cachedDataService.GetAll();

		query = GetRequested(query, request);
		query = GetFiltered(query, request.Filters);

		var routes = await _mapper.ProjectTo<Route>(query)
			.ToArrayAsync(cancellationToken);

		return routes;
	}

	private static IQueryable<RouteInfo> GetRequested(IQueryable<RouteInfo> query, SearchRequest request)
	{
		return query.Where(x => x.Origin == request.Origin 
		                        && x.Destination == request.Destination 
		                        && x.OriginDateTime == request.OriginDateTime);
	}

	bool IDataService.IsCached => true;

	private static IQueryable<RouteInfo> GetFiltered(IQueryable<RouteInfo> query, SearchFilters? filters)
	{
		if (filters?.MinTimeLimit != null)
		{
			query = query.Where(x => x.TimeLimit >= filters.MinTimeLimit);
		}

		if (filters?.DestinationDateTime != null)
		{
			query = query.Where(x => x.DestinationDateTime == filters.DestinationDateTime);
		}

		if (filters?.MaxPrice != null)
		{
			query = query.Where(x => x.Price <= filters.MaxPrice);
		}

		return query;
	}
}