using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BLL.Services;

public class DataProvidersHealthCheck : IHealthCheck
{
	private readonly ICachedDataService _cachedDataService;
	private readonly IEnumerable<IAvailable> _availableProviders;

	public DataProvidersHealthCheck(IEnumerable<IAvailable> availableProviders, 
		ICachedDataService cachedDataService)
	{
		_availableProviders = availableProviders;
		_cachedDataService = cachedDataService;
	}

	public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
	{
		var providersAvailableTasks = _availableProviders.Select(x => x.IsAvailableAsync(cancellationToken));

		var providersAvailable = await Task.WhenAll(providersAvailableTasks);

		var isHealthy = providersAvailable.Any(x => x == true) || await _cachedDataService.IsAvailable(cancellationToken);

		return isHealthy 
			? HealthCheckResult.Healthy("Сервис жив :)") 
			: new HealthCheckResult(context.Registration.FailureStatus, "Сервис блеет :(");
	}
}