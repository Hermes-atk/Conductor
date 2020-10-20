using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conductor.SystemAPIService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HealthCheckController : ControllerBase
	{

		/// <summary>
		/// The health check interface
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Get()
		{
			return Ok();
		}

	}
}
