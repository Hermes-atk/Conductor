using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conductor.APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GateWayController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "This is a Gateway.";
        }
    }
}
