using BLL.Interfaces;
using DAL.Context;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BLL.Services;

public class DataProvidersHealthCheck : IHealthCheck
{
	private readonly AppDataContext _context;
	private readonly IEnumerable<IAvailable> _availableProviders;

	public DataProvidersHealthCheck(AppDataContext context, 
		IEnumerable<IAvailable> availableProviders)
	{
		_context = context;
		_availableProviders = availableProviders;
	}

	public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
	{
		var providersAvailableTasks = _availableProviders.Select(x => x.IsAvailableAsync(cancellationToken));

		var providersAvailable = await Task.WhenAll(providersAvailableTasks);

		var isHealthy = providersAvailable.Any(x => x == true) || await _context.Database.CanConnectAsync(cancellationToken);

		return isHealthy 
			? HealthCheckResult.Healthy("Сервис жив :)") 
			: new HealthCheckResult(context.Registration.FailureStatus, "Сервис блеет :(");
	}
}