using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DAL.Interfaces;
using DAL.Model;

namespace BLL.Services;

public class ProviderOneSearchService : IDataService, IAvailable
{
	private readonly IProviderOneService _providerService;
	private readonly IMapper _mapper;

	public ProviderOneSearchService(IProviderOneService providerService, 
		IMapper mapper)
	{
		_providerService = providerService;
		_mapper = mapper;
	}

	public async Task<Route[]> GetDataAsync(SearchRequest request, CancellationToken cancellationToken)
	{
		var providerSearchRequest = _mapper.Map<ProviderOneSearchRequest>(request);

		var requestResult = await _providerService.GetRoutesAsync(providerSearchRequest, cancellationToken);

		var result = _mapper.Map<Route[]>(requestResult.Routes);

		return result;
	}

	public Task<bool> IsAvailableAsync(CancellationToken cancellationToken) => _providerService.IsAvailableAsync(cancellationToken);
}
