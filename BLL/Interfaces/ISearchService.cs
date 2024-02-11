using BLL.Model;

namespace BLL.Interfaces;

public interface ISearchService
{
	/// <summary>
	/// Поиск маршрутов
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken);
}
