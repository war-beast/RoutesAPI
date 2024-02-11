using BLL.Model;

namespace BLL.Interfaces;

public interface IDataService
{
	/// <summary>
	/// Получение данных от источника
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<Route[]> GetDataAsync(SearchRequest request, CancellationToken cancellationToken);

	bool IsCached => false;
}
