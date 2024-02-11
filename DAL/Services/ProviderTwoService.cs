using System.Net.Http.Json;
using DAL.Interfaces;
using DAL.Model;
using DAL.Model.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace DAL.Services;

public class ProviderTwoService : ProviderServicesBase, IProviderTwoService
{
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly ILogger<ProviderTwoService> _logger;

	public ProviderTwoService(IHttpClientFactory httpClientFactory,
		IOptions<ProviderTwoConnection> options, 
		ILogger<ProviderTwoService> logger)
	{
		_httpClientFactory = httpClientFactory;
		_logger = logger;
		var connection = options.Value;

		DataUrl = $"{connection.BaseUrl}/{connection.SearchEndpoint}";
		PingUrl = $"{connection.BaseUrl}/{connection.PingEndpoint}";
	}

	public async Task<ProviderTwoSearchResponse> GetRoutesAsync(ProviderTwoSearchRequest request, CancellationToken cancellationToken)
	{
		var client = _httpClientFactory.CreateClient();

		try
		{
			var requestResult = await client.PostAsJsonAsync(DataUrl, request, cancellationToken);

			if (requestResult.IsSuccessStatusCode)
			{
				var response = await requestResult.Content.ReadAsStringAsync(cancellationToken);

				return JsonSerializer.Deserialize<ProviderTwoSearchResponse>(response) ??
				       throw new InvalidOperationException($"Ошибка при десериализации ответа провайдера: {response}");
			}

			return new ProviderTwoSearchResponse { Routes = [] };
		}
		catch (Exception exc)
		{
			_logger.LogError(exc, "Ошибка запроса к {host}", DataUrl);
			return new ProviderTwoSearchResponse { Routes = [] };
		}
	}

	public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
	{
		var client = _httpClientFactory.CreateClient();

		try
		{
			var requestResult = await client.GetAsync(PingUrl, cancellationToken);

			return requestResult.IsSuccessStatusCode;
		}
		catch (Exception exc)
		{
			_logger.LogError(exc, "Ошибка запроса к {host}", PingUrl);
			return false;
		}
	}
}
