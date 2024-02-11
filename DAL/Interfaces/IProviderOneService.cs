using DAL.Model;

namespace DAL.Interfaces;

public interface IProviderOneService : IProviderAvailable
{
	/// <summary>
	/// Получить маршруты от провайдера
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<ProviderOneSearchResponse> GetRoutesAsync(ProviderOneSearchRequest request, CancellationToken cancellationToken);
}
