namespace DAL.Interfaces;

public interface IProviderAvailable
{
	/// <summary>
	/// Доступность поставщика маршрутов
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
}
