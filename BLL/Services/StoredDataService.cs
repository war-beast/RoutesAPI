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

	public async Task<SearchResponse> GetDataAsync(SearchRequest request, CancellationToken cancellationToken)
	{
		var query = _cachedDataService.GetAll();

		query = GetFiltered(query, request.Filters);

		var routes = await _mapper.ProjectTo<Route>(query)
			.ToArrayAsync(cancellationToken);

		var routesTimes = routes.Select(x => (x.DestinationDateTime - x.OriginDateTime).Minutes)
			.OrderBy(x => x)
			.ToArray();

		return new SearchResponse
		{
			Routes = routes,
			MaxPrice = routes.Max(x => x.Price),
			MinPrice = routes.Min(x => x.Price),
			MinMinutesRoute = routesTimes[0],
			MaxMinutesRoute = routesTimes[^1]
		};
	}

	bool IDataService.IsCached => true;

	private static IQueryable<RouteInfo> GetFiltered(IQueryable<RouteInfo> query, SearchFilters filters)
	{
		if (filters.MinTimeLimit != null)
		{
			query = query.Where(x => x.TimeLimit >= filters.MinTimeLimit);
		}

		if (filters.DestinationDateTime != null)
		{
			query = query.Where(x => x.DestinationDateTime == filters.DestinationDateTime);
		}

		if (filters.MaxPrice != null)
		{
			query = query.Where(x => x.Price <= filters.MaxPrice);
		}

		return query;
	}
}