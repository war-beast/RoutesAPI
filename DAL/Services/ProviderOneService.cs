using DAL.Interfaces;
using DAL.Model;
using DAL.Model.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DAL.Services;

public class ProviderOneService : IProviderOneService
{
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly ProviderOneConnection _connection;

	public ProviderOneService(IHttpClientFactory httpClientFactory,
		IOptions<ProviderOneConnection> options)
	{
		_httpClientFactory = httpClientFactory;
		_connection = options.Value;
	}

	public async Task<ProviderOneSearchResponse> GetRoutes(ProviderOneSearchRequest request)
	{
		var client = _httpClientFactory.CreateClient();

		var requestResult = await client.GetAsync($"{_connection.BaseUrl}/{_connection.SearchEndpoint}");

		if (requestResult.IsSuccessStatusCode)
		{
			var response = await requestResult.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<ProviderOneSearchResponse>(response) ?? throw new InvalidOperationException($"Ошибка при десериализации ответа провайдера: {response}");
		}

		throw new InvalidOperationException($"Ошибка при получении ответа провайдера: {requestResult.Content}");
	}

	public async Task<bool> IsAvailable()
	{
		var client = _httpClientFactory.CreateClient();

		var requestResult = await client.GetAsync($"{_connection.BaseUrl}/{_connection.PingEndpoint}");

		return requestResult.IsSuccessStatusCode
			? true
			: false;
	}
}
