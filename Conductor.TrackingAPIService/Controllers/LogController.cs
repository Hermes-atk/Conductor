using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conductor.TrackingAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpGet("query/list")]
        public IEnumerable<string> GetLog()
        {
            return new string[] { "12323", "34343", "00000" };
        }
    }
}
