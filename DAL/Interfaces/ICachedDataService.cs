using DAL.Entities;

namespace DAL.Interfaces;

public interface ICachedDataService
{
	Task<RouteInfo> GetById(Guid id);

	IQueryable<RouteInfo> GetAll();
}