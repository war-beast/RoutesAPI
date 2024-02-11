using DAL.Model;

namespace DAL.Interfaces;

public interface IProviderTwoService : IProviderAvailable
{
	/// <summary>
	/// Получить маршруты от провайдера
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<ProviderTwoSearchResponse> GetRoutesAsync(ProviderTwoSearchRequest request, CancellationToken cancellationToken);
}
