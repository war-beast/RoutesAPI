using DAL.Interfaces;
using DAL.Model;
using DAL.Model.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DAL.Services;

public class ProviderOneService : ProviderServicesBase, IProviderOneService
{
	private readonly IHttpClientFactory _httpClientFactory;

	public ProviderOneService(IHttpClientFactory httpClientFactory,
		IOptions<ProviderOneConnection> options)
	{
		_httpClientFactory = httpClientFactory;
		var connection = options.Value;

		DataUrl = $"{connection.BaseUrl}/{connection.SearchEndpoint}";
		PingUrl = $"{connection.BaseUrl}/{connection.PingEndpoint}";
	}

	public async Task<ProviderOneSearchResponse> GetRoutesAsync(ProviderOneSearchRequest request, CancellationToken cancellationToken)
	{
		var client = _httpClientFactory.CreateClient();

		var requestResult = await client.GetAsync(DataUrl, cancellationToken);

		if (requestResult.IsSuccessStatusCode)
		{
			var response = await requestResult.Content.ReadAsStringAsync(cancellationToken);

			return JsonSerializer.Deserialize<ProviderOneSearchResponse>(response) ?? throw new InvalidOperationException($"Ошибка при десериализации ответа провайдера: {response}");
		}

		throw new InvalidOperationException($"Ошибка при получении ответа провайдера: {requestResult.Content}");
	}

	public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
	{
		var client = _httpClientFactory.CreateClient();

		var requestResult = await client.GetAsync(PingUrl, cancellationToken);

		return requestResult.IsSuccessStatusCode
			? true
			: false;
	}
}
