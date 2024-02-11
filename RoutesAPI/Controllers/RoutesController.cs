using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RoutesAPI.Controllers
{
	[Route("api/v1")]
	[ApiController]
	public class RoutesController : ControllerBase
	{
		private readonly IRoutesService _routesService;

		public RoutesController(IRoutesService routesService)
		{
			_routesService = routesService;
		}

		[HttpGet("id:guid")]
		public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
		{
			var route = await _routesService.GetRoute(id, cancellationToken);

			return Ok(route);
		}
	}
}
