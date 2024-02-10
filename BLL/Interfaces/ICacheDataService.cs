using BLL.Model;

namespace BLL.Interfaces;

public interface ICacheDataService<in T>
{
	Task<SearchResponse> ReadAsync(T key, CancellationToken cancellationToken);

	Task WriteAsync(T key, SearchResponse item, CancellationToken cancellationToken);
}
