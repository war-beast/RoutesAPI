using BLL.Model;

namespace BLL.Interfaces;

public interface IFilterService
{
	Route[] FilterRoutes(IReadOnlyCollection<Route> source, SearchFilters filters);
}