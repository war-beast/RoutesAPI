namespace BLL.Interfaces;

public interface IDataProvidersFactory
{
	IEnumerable<IDataService> GetDataServices(bool cachedOnly);
}