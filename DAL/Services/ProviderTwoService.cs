using DAL.Interfaces;
using DAL.Model;
using DAL.Model.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace DAL.Services;

public class ProviderTwoService : IProviderTwoService
{
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly ProviderTwoConnection _connection;

	public ProviderTwoService(IHttpClientFactory httpClientFactory,
		IOptions<ProviderTwoConnection> options)
	{
		_httpClientFactory = httpClientFactory;
		_connection = options.Value;
	}

	public async Task<ProviderTwoSearchResponse> GetRoutesAsync(ProviderTwoSearchRequest request, CancellationToken cancellationToken)
	{
		var client = _httpClientFactory.CreateClient();

		var requestResult = await client.GetAsync($"{_connection.BaseUrl}/{_connection.SearchEndpoint}", cancellationToken);

		if (requestResult.IsSuccessStatusCode)
		{
			var response = await requestResult.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<ProviderTwoSearchResponse>(response) ?? throw new InvalidOperationException($"Ошибка при десериализации ответа провайдера {response}");
		}

		throw new InvalidOperationException($"Ошибка при получении ответа провайдера {requestResult.Content}");
	}

	public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
	{
		var client = _httpClientFactory.CreateClient();

		var requestResult = await client.GetAsync($"{_connection.BaseUrl}/{_connection.PingEndpoint}", cancellationToken);

		return requestResult.IsSuccessStatusCode
			? true
			: false;
	}
}
