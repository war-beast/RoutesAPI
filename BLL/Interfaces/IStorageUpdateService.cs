using BLL.Model;

namespace BLL.Interfaces;

public interface IStorageUpdateService
{
	Task SaveNewRoutes(IReadOnlyCollection<Route> routes, CancellationToken cancellationToken);
}