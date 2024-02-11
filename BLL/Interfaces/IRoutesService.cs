using BLL.Model;

namespace BLL.Interfaces;

public interface IRoutesService
{
	Task<Route> GetRouteAsync(Guid id, CancellationToken cancellationToken);
}