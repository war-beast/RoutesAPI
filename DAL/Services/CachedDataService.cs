using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services;

public class CachedDataService : ICachedDataService
{
	private readonly AppDataContext _context;

	public CachedDataService(AppDataContext context)
	{
		_context = context;
	}

	public Task<RouteInfo> GetById(Guid id, CancellationToken cancellationToken) =>
		_context.Routes
			.FirstAsync(x => x.Id == id, cancellationToken);

	public IQueryable<RouteInfo> GetAll() => _context.Routes;

	public async Task AddRoutes(IReadOnlyCollection<RouteInfo> routes, CancellationToken cancellationToken)
	{
		await _context.Routes.AddRangeAsync(routes, cancellationToken);

		await _context.SaveChangesAsync(cancellationToken);
	}

	public Task<bool> IsAvailable(CancellationToken cancellationToken) =>
		_context.Database.CanConnectAsync(cancellationToken);
}