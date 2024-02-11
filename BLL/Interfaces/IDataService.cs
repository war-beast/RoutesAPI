using BLL.Model;

namespace BLL.Interfaces;

public interface IDataService
{
	Task<Route> GetDataAsync(SearchRequest request, CancellationToken cancellationToken);

	bool IsCached => false;
}
