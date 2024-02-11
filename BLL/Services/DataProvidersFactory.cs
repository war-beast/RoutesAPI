using BLL.Interfaces;

namespace BLL.Services;

public class DataProvidersFactory : IDataProvidersFactory
{
	private readonly IEnumerable<IDataService> _services;

	public DataProvidersFactory(IEnumerable<IDataService> services)
	{
		_services = services;
	}

	public IEnumerable<IDataService> GetDataServices(bool cachedOnly)
	{
		return cachedOnly 
			? _services.Where(x => x.IsCached) 
			: _services;
	}
}