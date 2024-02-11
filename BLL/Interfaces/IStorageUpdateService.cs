using BLL.Model;

namespace BLL.Interfaces;

public interface IStorageUpdateService
{
	/// <summary>
	/// Закешировать маршруты для последующего быстрого доступа
	/// </summary>
	/// <param name="routes"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task SaveNewRoutes(IReadOnlyCollection<Route> routes, CancellationToken cancellationToken);
}