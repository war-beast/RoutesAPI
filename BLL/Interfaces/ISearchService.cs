using BLL.Model;

namespace BLL.Interfaces;

public interface ISearchService
{
	Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken);
}
