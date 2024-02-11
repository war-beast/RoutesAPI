using DAL.Entities;

namespace DAL.Interfaces;

public interface ICachedDataService
{
	/// <summary>
	/// Получить закешированный в БД маршрут по ИД
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<RouteInfo> GetById(Guid id, CancellationToken cancellationToken);

	/// <summary>
	/// Получить маршруты для последующей фильтрации
	/// </summary>
	/// <returns></returns>
	IQueryable<RouteInfo> GetAll();

	/// <summary>
	/// Закешировать в БД новые маршруты
	/// </summary>
	/// <param name="routes"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task AddRoutes(IReadOnlyCollection<RouteInfo> routes, CancellationToken cancellationToken);

	/// <summary>
	/// Доступность БД
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<bool> IsAvailable(CancellationToken cancellationToken);
}