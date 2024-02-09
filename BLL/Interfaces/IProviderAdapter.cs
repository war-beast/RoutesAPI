using BLL.Model;

namespace BLL.Interfaces;

public interface IProviderAdapter
{
	Task<SearchResponse> GetDataAsync(SearchRequest request, CancellationToken cancellationToken);

	Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
}
