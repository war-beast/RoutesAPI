using BLL.Model;

namespace BLL.Interfaces;

public interface IFilterService
{
	/// <summary>
	/// Фильтровать маршруты
	/// </summary>
	/// <param name="source">Исходный список</param>
	/// <param name="filters">Фильтр</param>
	/// <returns></returns>
	Route[] FilterRoutes(IReadOnlyCollection<Route> source, SearchFilters filters);
}