using BLL.Comparers;
using BLL.Interfaces;
using BLL.Model;

namespace BLL.Services;

public class SearchService : ISearchService
{
	private readonly IDataProvidersFactory _providersFactory;
	private readonly IStorageUpdateService _storageUpdateService;
	private readonly IFilterService _filterService;

	public SearchService(IDataProvidersFactory providersFactory, 
		IStorageUpdateService storageUpdateService, 
		IFilterService filterService)
	{
		_providersFactory = providersFactory;
		_storageUpdateService = storageUpdateService;
		_filterService = filterService;
	}

	public async Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken)
	{
		var providers = _providersFactory.GetDataServices(request.Filters?.OnlyCached ?? false)
			.ToArray();

		IEnumerable<Route> resultRoutes = Enumerable.Empty<Route>();

		var outerProviderTasks = providers.Where(x => !x.IsCached)
				.Select(x => x.GetDataAsync(request, cancellationToken));

		//По идее можно и задачу получения из БД тоже параллельно запустить,
		//но если надо будет с дублированием разбираться, то проще записи из БД получить отдельным списком,
		//чтобы из новых данных убрать уже существующие в БД
		var outerProviderData = await Task.WhenAll(outerProviderTasks);

		//Если нет необходимости убирать дубли маршрутов, то можно не использовать
		RoutesWithoutIdComparer copmarer = new();
		foreach (var routes in outerProviderData)
		{
			resultRoutes = resultRoutes.Union(routes, copmarer);
		}

		var outerProvidersRoutes = resultRoutes as Route[] ?? resultRoutes.ToArray();

		//По хорошему перед добавлением в БД надо было бы проверить на дублировние новых маршрутов с теми что уже есть в БД, но чтобы не переусложнять, я это делать тут не буду.
		await _storageUpdateService.SaveNewRoutes(outerProvidersRoutes, cancellationToken);

		//В общем случае может быть несколько разных кешей, и где-то один и тот же маршрут может появитсья дважды
		RoutesByIdComparer idComparer = new();
		foreach (var provider in providers.Where(x => x.IsCached))
		{
			resultRoutes = resultRoutes.Union(await provider.GetDataAsync(request, cancellationToken), idComparer);
		}

		var resultRouts = request.Filters != null 
			? _filterService.FilterRoutes(resultRoutes.ToArray(), request.Filters)
			: resultRoutes.ToArray();

		var routesTimes = resultRouts.Select(x => (int)(x.DestinationDateTime - x.OriginDateTime).TotalMinutes)
			.OrderBy(x => x)
			.ToArray();

		return new SearchResponse
		{
			Routes = resultRouts,
			MaxPrice = resultRouts.Length > 0 ? resultRouts.Max(x => x.Price) : default,
			MinPrice = resultRouts.Length > 0 ? resultRouts.Min(x => x.Price) : default,
			MinMinutesRoute = resultRouts.Length > 0 ? routesTimes[0] : default,
			MaxMinutesRoute = resultRouts.Length > 0 ? routesTimes[^1] : default
		};
	}
}