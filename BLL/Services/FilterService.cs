using BLL.Interfaces;
using BLL.Model;

namespace BLL.Services;

public class FilterService : IFilterService
{
	public Route[] FilterRoutes(IReadOnlyCollection<Route> source, SearchFilters filters)
	{
		IEnumerable<Route> result = source;

		if (filters.MinTimeLimit != null)
		{
			result = result.Where(x => x.TimeLimit >= filters.MinTimeLimit);
		}
		if (filters.DestinationDateTime != null)
		{
			result = result.Where(x => x.DestinationDateTime == filters.DestinationDateTime);
		}

		if (filters.MaxPrice != null)
		{
			result = result.Where(x => x.Price <= filters.MaxPrice);
		}

		return result
			.ToArray();
	}
}