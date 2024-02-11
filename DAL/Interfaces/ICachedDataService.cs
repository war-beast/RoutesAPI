using DAL.Entities;

namespace DAL.Interfaces;

public interface ICachedDataService
{
	Task<RouteInfo> GetById(Guid id, CancellationToken cancellationToken);

	IQueryable<RouteInfo> GetAll();

	Task AddRoutes(IReadOnlyCollection<RouteInfo> routes, CancellationToken cancellationToken);
}