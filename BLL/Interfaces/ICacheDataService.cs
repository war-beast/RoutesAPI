using BLL.Model;

namespace BLL.Interfaces;

public interface ICacheDataService
{
	Task<SearchResponse> ReadAsync(string key, CancellationToken cancellationToken);

	Task WriteAsync(string key, SearchResponse item, CancellationToken cancellationToken);
}
