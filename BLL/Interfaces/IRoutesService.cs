using BLL.Model;

namespace BLL.Interfaces;

public interface IRoutesService
{
	/// <summary>
	/// Получить маршрут из БД по ИД
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<Route> GetRouteAsync(Guid id, CancellationToken cancellationToken);
}