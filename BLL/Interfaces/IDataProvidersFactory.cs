namespace BLL.Interfaces;

public interface IDataProvidersFactory
{
	/// <summary>
	/// Получить источники маршрутов
	/// </summary>
	/// <param name="cachedOnly">Только закешированные</param>
	/// <returns></returns>
	IEnumerable<IDataService> GetDataServices(bool cachedOnly);
}