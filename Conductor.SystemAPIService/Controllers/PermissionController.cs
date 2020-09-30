using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conductor.SystemAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Permission", "James Li" };
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return $"Permission service - {id}";
        }

        [HttpGet("add/key")]
        public string AddKey()
        {
            return "Permission add";
        }

        [HttpGet("permission/get/{name}")]
        public string GetPermission(string name)
        {
            return $"Get Permission - {name}";
        }
    }
}
