using BLL.Model;

namespace BLL.Interfaces;

public interface IRoutesService
{
	Task<Route> GetRoute(Guid id, CancellationToken cancellationToken);
}