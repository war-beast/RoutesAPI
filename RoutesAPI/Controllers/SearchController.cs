using BLL.Interfaces;
using BLL.Model;
using Microsoft.AspNetCore.Mvc;

namespace RoutesAPI.Controllers
{
	[Route("api/v1/search")]
	[ApiController]
	public class SearchController : ControllerBase
	{
		private readonly ISearchService _searchService;

		public SearchController(ISearchService searchService)
		{
			_searchService = searchService;
		}

		[HttpPost]
		public async Task<IActionResult> Search(SearchRequest request, CancellationToken cancellationToken)
		{
			var result = await _searchService.SearchAsync(request, cancellationToken);

			return Ok(result);
		}
	}
}
