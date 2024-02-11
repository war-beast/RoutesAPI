namespace BLL.Interfaces;

public interface IAvailable
{
	/// <summary>
	/// Доступность ресурса
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
}